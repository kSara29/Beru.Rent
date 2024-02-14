using Bff.Application.Contracts;
using Bff.Application.JsonOptions;
using Bff.Application.Handlers;
using Common;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Application.Services;

public class UserService
     (ServiceHandler serviceHandler, 
        IOptions<RequestToUserApi> jsonOptions) : IUserService
{
    public async Task<ResponseModel<UserDtoResponce>> GetUserByEmailAsync(string request) => 
        await serviceHandler.GetConnectionHandler<UserDtoResponce>(serviceHandler.CreateConnectionUrlWithQuery
                (jsonOptions.Value.Url, "api/user/getByMail?Email=", request));
    
    public async Task<ResponseModel<UserDtoResponce>> GetUserByIdAsync(string request) =>
        await serviceHandler.GetConnectionHandler<UserDtoResponce>
            (serviceHandler.CreateConnectionUrlWithQuery
                (jsonOptions.Value.Url, "api/user/getById?Id=", request));
    

    public async Task<ResponseModel<UserDtoResponce>> GetUserByNameAsync(string request) =>
        await serviceHandler.GetConnectionHandler<UserDtoResponce>
            (serviceHandler.CreateConnectionUrlWithQuery
                (jsonOptions.Value.Url, "api/user/getByName?UserName=", request));

    public async Task<ResponseModel<UserDtoResponce>> DeleteUserAsync(DeleteUserByIdRequest request)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/delete");
        return await serviceHandler.PostConnectionHandler<DeleteUserByIdRequest, UserDtoResponce>(url, request);
    }

    public async Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto request)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/update");
        var result = await serviceHandler.PostConnectionHandler<UpdateUserDto, UserDtoResponce>(url, request);
        return result;
    }

    public async Task<ResponseModel<UserDtoResponce>> CreateUserAsync(CreateUserDto request)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/create");
        return await serviceHandler.PostConnectionHandler<CreateUserDto, UserDtoResponce>(url, request);
    }
}