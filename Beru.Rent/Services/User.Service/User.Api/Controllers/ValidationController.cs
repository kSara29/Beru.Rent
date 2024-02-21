using Microsoft.AspNetCore.Mvc;
using User.Application.Contracts;

namespace User.Api.Controllers;

public class ValidationController(IUserService userService): Controller
{
    [AcceptVerbs("GET", "POST")]
    public async Task<bool> CheckName(string userName)
    {
        var check =  await userService.CheckOfExists("login", userName);
        return !check;
    }
    
    [AcceptVerbs("GET", "POST")]
    public async Task<bool> EmailCheck(string email)
    {
        var check = await userService.CheckOfExists("email", email);
        return !check;
    }
    
    [AcceptVerbs("GET", "POST")]
    public async Task<bool> PhoneCheck(string phone)
    {
        var check = await userService.CheckOfExists("phoneNumber", phone);
        return !check;
    }
}