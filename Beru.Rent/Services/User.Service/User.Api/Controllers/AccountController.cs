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
    IIdentityServerInteractionService interaction)
    : Controller
{
    [HttpGet("register")]
    public async Task<IActionResult> Register(string? returnUrl)
    {
        return View();
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel modelVm)
    {
        if (ModelState.IsValid)
        {
            var model = new CreateUserDto()
            {
                FirstName = modelVm.FirstName,
                LastName = modelVm.LastName,
                UserName = modelVm.UserName,
                Mail = modelVm.Email,
                Phone = modelVm.Phone,
                Iin = modelVm.Iin,
                Password = modelVm.Password,
                ConfirmPassword = modelVm.ConfirmPassword,
                ReturnUrl = modelVm.ReturnUrl
            };
            
            var phoneResult = await validator.FindUserByPhoneNumberAsync(model.Phone);
            if (phoneResult)
            {
                ModelState.AddModelError("Phone", "номер телефона не верный");
                return View(modelVm);
            }
            
            if (!string.IsNullOrWhiteSpace(model.Mail) && 
                await validator.FindUserByEmailNumberAsync(model.Mail) is not null)
            {
                ModelState.AddModelError("Mail", "Email не верный");
                return View(modelVm);
            }
            
            if (!string.IsNullOrWhiteSpace(model.UserName) && 
                await validator.FindUserByUserNameAsync(model.UserName) is not null)
            {
                ModelState.AddModelError("UserName", "UserName не верный");
                return View(modelVm);
            }
            
            var result = await userService.CreateUserAsync(model, model.Password);
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(result);
                var confirmLink = 
                    Url.Action("ConfirmEmail", "Account",
                        new { userId = result.Id, token, model.ReturnUrl }, Request.Scheme);
                await emailSender.SendEmailAsync
                (result.Email!, 
                    "Подтверждение адреса электронной почты", 
                    $"Подтвердите свой адрес электронной почты, перейдя по ссылке: " +
                    $"<a href='{confirmLink}'>confirm email</a>");

                return Ok("Check your email for confirmation link");
            }
        }

        return View();
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token, string returnUrl)
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
            return RedirectToAction("Login", new { returnUrl });
        }

        return BadRequest("Email confirmation failed");
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

        var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
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
            await HttpContext.SignOutAsync();
        }
        foreach (var cookie in Request.Cookies.Keys)
        {
            Response.Cookies.Delete(cookie);
        }
        var logoutContext = await interaction.GetLogoutContextAsync(logoutId);
        return Redirect(logoutContext.PostLogoutRedirectUri ?? "/");
    }
}