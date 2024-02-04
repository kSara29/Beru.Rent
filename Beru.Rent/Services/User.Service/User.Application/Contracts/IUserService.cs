using Common;
using User.Dto;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace User.Application.Contracts;

public interface IUserService
{
    Task<Domain.Models.User> CreateUserAsync(CreateUserDto model, string password);
    Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto model);
    Task<UserDtoResponce> GetUserByIdAsync(string userId);
    Task<UserDtoResponce> GetUserByMailAsync(string mail);
    Task<UserDtoResponce> GetUserByNameAsync(string userName);
    Task<UserDtoResponce> DeleteUserAsync(string userId);
}