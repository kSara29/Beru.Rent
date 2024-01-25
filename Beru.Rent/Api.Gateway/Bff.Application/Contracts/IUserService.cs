using Common;
using User.Dto;

namespace Bff.Application.Contracts;

public interface IUserService
{
    Task<ResponseModel<UserDtoResponce>> GetUserByEmailAsync(GetUserByEmailRequest request);
    Task<ResponseModel<UserDtoResponce>> GetUserByIdAsync(GetUserByIdRequest request);
    Task<ResponseModel<UserDtoResponce>> GetUserByNameAsync(GetUserByUserNameRequest request);
    Task<ResponseModel<UserDtoResponce>> DeleteUserAsync(DeleteUserByIdRequest request);
    Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto request);
}