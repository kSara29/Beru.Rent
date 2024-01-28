using Bff.Application.Contracts;
using Bff.Application.JsonOptions;
using Bff.Application.Maping;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Dto;

namespace Bff.Application.Services;

public class UserService
    (ServiceHandler<UserDtoResponce> serviceHandler, 
        IOptions<RequestToUserApi> jsonOptions) : IUserService
{
    public async Task<ResponseModel<UserDtoResponce>> GetUserByEmailAsync(GetUserByEmailRequest request) => 
        await serviceHandler.GetConnectionHandler
            (serviceHandler.CreateConnectionUrlWithQuery
                (jsonOptions.Value.Url, "api/user/getByMail?Email=", request.Email));
    
    public async Task<ResponseModel<UserDtoResponce>> GetUserByIdAsync(GetUserByIdRequest request) =>
        await serviceHandler.GetConnectionHandler
            (serviceHandler.CreateConnectionUrlWithQuery
                (jsonOptions.Value.Url, "api/user/getById?Id=", request.Id));
    

    public async Task<ResponseModel<UserDtoResponce>> GetUserByNameAsync(GetUserByUserNameRequest request) =>
        await serviceHandler.GetConnectionHandler
            (serviceHandler.CreateConnectionUrlWithQuery
                (jsonOptions.Value.Url, "api/user/getByName?UserName=", request.UserName));

    public async Task<ResponseModel<UserDtoResponce>> DeleteUserAsync(DeleteUserByIdRequest request)
    {
        var jsonContent = JsonConvert.SerializeObject(request);
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/delete");
        return await serviceHandler.PostConnectionHandler(url, jsonContent);
    }

    public async Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto request)
    {
        var jsonContent = JsonConvert.SerializeObject(request);
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/update");
        var result = await serviceHandler.PostConnectionHandler(url, jsonContent);
        return result;
    }

    public async Task<ResponseModel<UserDtoResponce>> CreateUserAsync(CreateUserDto request)
    {
        var jsonContent = JsonConvert.SerializeObject(request);
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/create");
        return await serviceHandler.PostConnectionHandler(url, jsonContent);
    }
}