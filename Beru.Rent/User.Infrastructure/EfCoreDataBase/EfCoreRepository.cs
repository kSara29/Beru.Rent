using Microsoft.AspNetCore.Identity;
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
        await _userManager.CreateAsync(model, password);
        return model;
    }

    public async Task<Domain.Models.User> GetUserByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        return user;
    }

    public async Task<Domain.Models.User> UpdateUserAsync(Domain.Models.User user)
    {
        await _userManager.UpdateAsync(user);
        return user;
    }
}