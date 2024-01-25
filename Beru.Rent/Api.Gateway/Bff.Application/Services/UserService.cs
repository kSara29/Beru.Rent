using System.Text.Json;
using Bff.Application.Contracts;
using Bff.Application.JsonOptions;
using Bff.Application.Maping;
using Common;
using Microsoft.Extensions.Options;
using User.Dto;

namespace Bff.Application.Services;

public class UserService(UserServiceMaping userServiceMaping, IOptions<RequestToUserApi> jsonOptions) : IUserService
{
    public async Task<ResponseModel<UserDtoResponce>> GetUserByEmailAsync(GetUserByEmailRequest request)
    {
        var httpConnection =
            await userServiceMaping.HttpGetConnection(string.Concat(jsonOptions.Value.GetUserByEmail, request.Email));

        var responce = 
            await userServiceMaping.UserResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> GetUserByIdAsync(GetUserByIdRequest request)
    {
        var httpConnection =
            await userServiceMaping.HttpGetConnection(string.Concat(jsonOptions.Value.GetUserById, request.Id));

        var responce = 
            await userServiceMaping.UserResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> GetUserByNameAsync(GetUserByUserNameRequest request)
    {
        var httpConnection =
            await userServiceMaping.HttpGetConnection(string.Concat(jsonOptions.Value.GetUserByName, request.UserName));

        var responce = 
            await userServiceMaping.UserResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> DeleteUserAsync(DeleteUserByIdRequest request)
    {
        var content = userServiceMaping.GetContentString(request.Id, nameof(request.Id));
        var httpConnection =
            await userServiceMaping.HttpPostConnection(jsonOptions.Value.DeleteUser, content);
        
        var responce = 
            await userServiceMaping.UserResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto request)
    {
        var content = JsonSerializer.Serialize(request);
        var httpConnection =
            await userServiceMaping.HttpPostConnection(jsonOptions.Value.UpdateUser, content);
        
        var responce = 
            await userServiceMaping.UserResponceModelMaping(httpConnection);
        return responce;
    }
}