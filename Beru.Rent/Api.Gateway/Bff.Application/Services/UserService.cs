using System.Text.Json;
using Bff.Application.Contracts;
using Bff.Application.JsonOptions;
using Bff.Application.Maping;
using Common;
using Microsoft.Extensions.Options;
using User.Dto;

namespace Bff.Application.Services;

public class UserService(ServiceMaping<UserDtoResponce> serviceMaping, IOptions<RequestToUserApi> jsonOptions) : IUserService
{
    public async Task<ResponseModel<UserDtoResponce>> GetUserByEmailAsync(GetUserByEmailRequest request)
    {
        var httpConnection =
            await serviceMaping.HttpGetConnection(string.Concat(jsonOptions.Value.GetUserByEmail, request.Email));

        var responce = 
            await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> GetUserByIdAsync(GetUserByIdRequest request)
    {
        var httpConnection =
            await serviceMaping.HttpGetConnection(string.Concat(jsonOptions.Value.GetUserById, request.Id));

        var responce = 
            await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> GetUserByNameAsync(GetUserByUserNameRequest request)
    {
        var httpConnection =
            await serviceMaping.HttpGetConnection(string.Concat(jsonOptions.Value.GetUserByName, request.UserName));

        var responce = 
            await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> DeleteUserAsync(DeleteUserByIdRequest request)
    {
        var content = serviceMaping.GetContentString(request.Id, nameof(request.Id));
        var httpConnection =
            await serviceMaping.HttpPostConnection(jsonOptions.Value.DeleteUser, content);
        
        var responce = 
            await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto request)
    {
        var content = JsonSerializer.Serialize(request);
        var httpConnection =
            await serviceMaping.HttpPostConnection(jsonOptions.Value.UpdateUser, content);
        
        var responce = 
            await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> CreateUserAsync(CreateUserDto request)
    {
        var content = JsonSerializer.Serialize(request);
        var httpConnection =
            await serviceMaping.HttpPostConnection(jsonOptions.Value.CreateUser, content);
        
        var responce = 
            await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }

    public async Task<ResponseModel<UserDtoResponce>> GetAuthService()
    {
        var httpConnection =
            await serviceMaping.HttpGetConnection(jsonOptions.Value.Auth);
        var responce = await serviceMaping.ResponceModelMaping(httpConnection);
        return responce;
    }
}