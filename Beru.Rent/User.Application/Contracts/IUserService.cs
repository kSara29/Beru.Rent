using User.Application.DTO;

namespace User.Application.Contracts;

public interface IUserService
{
    Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password);
}