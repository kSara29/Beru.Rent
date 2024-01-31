using User.Dto;

namespace User.Application.Contracts;

public interface IUserService
{
    Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password);
    Task<Domain.Models.User> UpdateUserAsync(UpdateUserDto model);
    Task<UserDtoResponce> GetUserByIdAsync(string userId);
    Task<UserDtoResponce> GetUserByMailAsync(string mail);
    Task<UserDtoResponce> GetUserByNameAsync(string userName);
    Task<UserDtoResponce> DeleteUserAsync(string userId);
}