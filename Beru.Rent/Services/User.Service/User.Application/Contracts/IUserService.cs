using User.Dto;

namespace User.Application.Contracts;

public interface IUserService
{
    Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password);
    Task<Domain.Models.User> UpdateUserAsync(UpdateUserDto model);
    Task<UserDto> GetUserByIdAsync(string userId);
    Task<UserDto> GetUserByMailAsync(string mail);
    Task<UserDto> GetUserByNameAsync(string userName);
    Task<UserDto> DeleteUserAsync(string userId);
}