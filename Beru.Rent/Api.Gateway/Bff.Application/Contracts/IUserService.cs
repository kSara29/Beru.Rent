using Common;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Application.Contracts;

public interface IUserService
{
    Task<ResponseModel<UserDtoResponce>> GetUserByEmailAsync(string request);
    Task<ResponseModel<UserDtoResponce>> GetUserByIdAsync(string request);
    Task<ResponseModel<UserDtoResponce>> GetUserByNameAsync(string request);
    Task<ResponseModel<UserDtoResponce>> DeleteUserAsync(DeleteUserByIdRequest request);
    Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto request);
    Task<ResponseModel<UserDtoResponce>> CreateUserAsync(CreateUserDto request);
}