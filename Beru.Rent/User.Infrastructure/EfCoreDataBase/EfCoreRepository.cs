using Microsoft.AspNetCore.Identity;
using User.Application.Contracts;
using User.Application.DTO;
using User.Infrastructure.Context;

namespace User.Infrastructure.EfCoreDataBase;

public class EfCoreRepository: IUserRepository
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
}