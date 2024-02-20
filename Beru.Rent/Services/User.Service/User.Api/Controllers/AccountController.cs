using IdentityServer4;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Api.Models;

namespace User.Api.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<Domain.Models.User> _signInManager;
    private readonly UserManager<Domain.Models.User> _userManager;
    private readonly IIdentityServerInteractionService _interaction;


    public AccountController
        (SignInManager<Domain.Models.User> signInManager, UserManager<Domain.Models.User> userManager, IIdentityServerInteractionService interaction)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _interaction = interaction;
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

        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user is null)
        {
            ModelState.AddModelError("UserName", "User not found");
            return View(model);
        }

        var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
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
        if (User.Identity!.IsAuthenticated)
        {
            await HttpContext.SignOutAsync();
        }
        foreach (var cookie in Request.Cookies.Keys)
        {
            Response.Cookies.Delete(cookie);
        }
        var logoutContext = await _interaction.GetLogoutContextAsync(logoutId);
        return Redirect(logoutContext.PostLogoutRedirectUri ?? "/");
    }
}