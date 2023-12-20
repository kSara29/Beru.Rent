using User.Application.Contracts;
using User.Application.DTO;
using User.Infrastructure.Context;

namespace User.Infrastructure.EfCoreDataBase;

public class EfCoreRepository: IUserRepository
{
    private readonly UserContext _db;
    public EfCoreRepository(UserContext db)
    {
        _db = db;
    }
    
    public async Task<Domain.Models.User> CreateUserAsync(Domain.Models.User model)
    {
        await _db.Users.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }
}