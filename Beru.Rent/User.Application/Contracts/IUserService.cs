using User.Application.DTO;

namespace User.Application.Contracts;

public interface IUserService
{
    Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password);
    Task<Domain.Models.User> UpdateUserAsync(UpdateUserDto model);
}