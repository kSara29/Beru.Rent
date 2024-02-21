using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.Application.Contracts;
using User.Infrastructure.Context;

namespace User.Infrastructure.EfCoreDataBase;

public class EfCoreRepository : IUserRepository
{
    private readonly UserContext _db;
    private readonly UserManager<Domain.Models.User> _userManager;
    public EfCoreRepository(UserContext db, UserManager<Domain.Models.User> userManager)
    {
        _db = db;
        _userManager = userManager;
    }
    
    public async Task<Domain.Models.User> CreateUserAsync(Domain.Models.User model, string password)
    {
        var result = await _userManager.CreateAsync(model, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(model, "user");
        }
        return model;
    }

    public async Task<Domain.Models.User?> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return user;
    }
    
    public async Task<Domain.Models.User> GetUserByMailAsync(string mail)
    {
        var user = await _userManager.FindByEmailAsync(mail);
        return user;
    }

    public async Task<Domain.Models.User> GetUserByUserNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        return user;
    }

    public async Task<bool> GetUserByPhoneAsync(string phone)
    {
        return await _db.Users.AnyAsync(u => u.PhoneNumber == phone);
    }

    public async Task<Domain.Models.User> UpdateUserAsync(Domain.Models.User user)
    {
        await _userManager.UpdateAsync(user);
        return user;
    }

    public async Task<Domain.Models.User> DeleteUserAsync(Domain.Models.User user)
    {
        await _userManager.DeleteAsync(user);
        return user;
    }

    public async Task<bool> CheckOfExists(string field, string checkString)
    {
        switch (field)
        {
            case "login":
                return await _db.Users.AnyAsync(u => u.UserName.ToLower() == checkString.ToLower());
            case "email":
                return await _db.Users.AnyAsync(u => u.Email.ToLower() == checkString.ToLower());
            case "phoneNumber":
                return await _db.Users.AnyAsync(u => u.PhoneNumber == checkString);
        }

        return false;
    }
}