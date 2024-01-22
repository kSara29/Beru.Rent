using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Api.Models;

namespace User.Api.Controllers;

public class AuthController : Controller
{
    private readonly SignInManager<Domain.Models.User> _signInManager;
    private readonly UserManager<Domain.Models.User> _userManager;

    public AuthController
        (SignInManager<Domain.Models.User> signInManager, UserManager<Domain.Models.User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login()
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
}