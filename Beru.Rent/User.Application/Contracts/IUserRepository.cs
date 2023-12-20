using User.Application.DTO;

namespace User.Application.Contracts;

public interface IUserRepository
{
    Task<Domain.Models.User> CreateUserAsync(Domain.Models.User model);
}