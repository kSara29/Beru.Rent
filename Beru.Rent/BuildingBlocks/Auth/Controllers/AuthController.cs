using Auth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IHttpClientFactory _httpClient;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpClientFactory httpClient)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _httpClient = httpClient;
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var client = _httpClient.CreateClient();

        var user = await client.GetAsync("https://localhost:7258/api/user/getById?id=6bdd3d0c-51e3-4d8b-8998-410cd6ee7e17");

        if (user is null)
        {
            ModelState.AddModelError("UserName", "User not found");
            return View(model);
        }

        // var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
        // if (signInResult.Succeeded)
        // {
        //     return Redirect(model.ReturnUrl);
        // }
        ModelState.AddModelError("UserName", "Somthing went wrong");
        return Redirect(model.ReturnUrl);
    }
}