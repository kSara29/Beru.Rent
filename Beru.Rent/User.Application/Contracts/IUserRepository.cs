using User.Application.DTO;

namespace User.Application.Contracts;

public interface IUserRepository
{
    Task<Domain.Models.User> CreateUserAsync(Domain.Models.User model, string password);
    Task<Domain.Models.User> GetUserByIdAsync(string id);
    Task<Domain.Models.User> UpdateUserAsync(Domain.Models.User user);
}