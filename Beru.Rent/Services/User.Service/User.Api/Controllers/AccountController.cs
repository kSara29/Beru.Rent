using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using User.Api.Models;
using User.Application.Contracts;
using User.Application.Validation;
using User.Dto.RequestDto;

namespace User.Api.Controllers;

public class AccountController(
    IUserService userService,
    UserManager<Domain.Models.User> userManager,
    SignInManager<Domain.Models.User> signInManager,
    IEmailSender emailSender,
    IUserValidator validator,
    CreateUserValidation createUserValidation,
    IResponseMapper mapper,
    IIdentityServerInteractionService interaction)
    : Controller
{
    // Здесь IUserService предполагается ваш сервис пользователя
    // Замените IEmailSender на ваш интерфейс для отправки электронной почты

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto model)
    {
        var validationResult = await createUserValidation.ValidateAsync(model);
        if (!validationResult.IsValid)
        {
            var resp = await mapper
                .HandleFailedResponse(validationResult);
            return BadRequest(resp);
        }
        
        var phoneResult = await validator.FindUserByPhoneNumberAsync(model.Phone);
        if (phoneResult)
        {
            var resp = await mapper
                .HandleFailedResponseForPhone();
            return BadRequest(resp);
        }
        
        var mailResult = await validator.FindUserByEmailNumberAsync(model.Mail);
        if (mailResult is not null)
        {
            var resp = await mapper
                .HandleFailedResponseForEmail();
            return BadRequest(resp);
        }
        
        var userNameResult = await validator.FindUserByUserNameAsync(model.UserName);
        if (userNameResult is not null)
        {
            var resp = await mapper
                .HandleFailedResponseForUserName();
            return BadRequest(resp);
        }
        var result = await userService.CreateUserAsync(model, model.Password);
        if (result is not null)
        {

            var token = await userManager.GenerateEmailConfirmationTokenAsync(result);
            var confirmLink = 
                Url.Action("ConfirmEmail", "Account", 
                    new { userId = result.Id, token }, Request.Scheme);
            await emailSender.SendEmailAsync
                (result.Email, 
                    "Подтверждение адреса электронной почты", 
                    $"Подтвердите свой адрес электронной почты, перейдя по ссылке: " +
                    $"<a href='{confirmLink}'>link</a>");

            return Ok("Check your email for confirmation link");
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
        {
            return BadRequest("User Id and token are required");
        }

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return BadRequest("Invalid user Id");
        }

        var result = await userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return Ok("Email confirmed successfully");
        }
        else
        {
            return BadRequest("Email confirmation failed");
        }
    }
    

    [HttpGet]
    public IActionResult Login(string? returnUrl)
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await userManager.FindByNameAsync(model.UserName);

        if (user is null)
        {
            ModelState.AddModelError("UserName", "User not found");
            return View(model);
        }

        var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
        if (signInResult.Succeeded)
        {
            return Redirect(model.ReturnUrl);
        }
        ModelState.AddModelError("UserName", "Somthing went wrong");
        return Redirect(model.ReturnUrl);
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout(string logoutId)
    {
        if (User?.Identity.IsAuthenticated == true)
        {
            await HttpContext.SignOutAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme);
        }
        var logoutContext = await interaction.GetLogoutContextAsync(logoutId);
        return Redirect(logoutContext.PostLogoutRedirectUri ?? "/");
    }
}