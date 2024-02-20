using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Api.Models;
using User.Api.Services;
using User.Application.Contracts;
using User.Application.Validation;
using User.Dto.RequestDto;

namespace User.Api.Controllers;

public class AccountController(
    IUserService userService,
    UserManager<Domain.Models.User> userManager,
    SignInManager<Domain.Models.User> signInManager,
    EmailService emailSender,
    IUserValidator validator,
    CreateUserValidation createUserValidation,
    IResponseMapper mapper,
    IIdentityServerInteractionService interaction)
    : Controller
{

    [HttpGet("register")]
    public async Task<IActionResult> Register(string? returnUrl)
    {
        return View();
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserDto model)
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
        
        if (!string.IsNullOrWhiteSpace(model.Mail) && 
            await validator.FindUserByEmailNumberAsync(model.Mail) is not null)
        {
            var resp = await mapper
                .HandleFailedResponseForEmail();
            return BadRequest(resp);
        }
        
        if (!string.IsNullOrWhiteSpace(model.UserName) && 
            await validator.FindUserByUserNameAsync(model.UserName) is not null)
        {
            var resp = await mapper
                .HandleFailedResponseForUserName();
            return BadRequest(resp);
        }
        
        var result = await userService.CreateUserAsync(model, model.Password);
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(result);
            var confirmLink = 
                Url.Action("ConfirmEmail", "Account",
                    new { userId = result.Id, token, returnUrl = model.ReturnUrl }, Request.Scheme);
            await emailSender.SendEmailAsync
            (result.Email!, 
                "Подтверждение адреса электронной почты", 
                $"Подтвердите свой адрес электронной почты, перейдя по ссылке: " +
                $"<a href='{confirmLink}'>confirm email</a>");

            return Ok("Check your email for confirmation link");
        }
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token, string returnUrl)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            return BadRequest("User Id and token are required");

        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return BadRequest("Invalid user Id");

        var result = await userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded) return RedirectToAction("Login");
        return BadRequest();
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
        
        if (!user.EmailConfirmed)
        {
            ModelState.AddModelError("EmailConfirmed", "Подтвердите почту");
            return View(model);
        }
        
        var signInResult = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (signInResult.Succeeded)
        {
            return Redirect(model.ReturnUrl!);
        }
        ModelState.AddModelError("UserName", "Something went wrong");
        return View(model);
    }
    
    [HttpGet]
    public async Task<IActionResult> Logout(string logoutId)
    {
        if (User.Identity!.IsAuthenticated)
        {
            await HttpContext.SignOutAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme);
        }
        var logoutContext = await interaction.GetLogoutContextAsync(logoutId);
        return Redirect(logoutContext.PostLogoutRedirectUri ?? "/");
    }
}