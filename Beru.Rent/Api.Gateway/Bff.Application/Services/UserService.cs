using Bff.Application.Contracts;
using Bff.Application.JsonOptions;
using Bff.Application.Handlers;
using Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using User.Dto.RequestDto;
using User.Dto.ResponseDto;

namespace Bff.Application.Services;

public class UserService
     (ServiceHandler serviceHandler, ILogger<UserService> logger,
        IOptions<RequestToUserApi> jsonOptions) : IUserService
{
    public async Task<ResponseModel<UserDtoResponce>> GetUserByEmailAsync(string request)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/user/getByMail?Email=", request);

        logger.LogInformation("Отправляем GET запрос в UserService {@url}", url);
        
        return await serviceHandler.GetConnectionHandler<UserDtoResponce>(url);
    }
    
    public async Task<ResponseModel<UserDtoResponce>> GetUserByIdAsync(string request)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/user/getById?Id=", request);
        
        logger.LogInformation("Отправляем GET запрос в UserService {@url}", url);
        
        return await serviceHandler.GetConnectionHandler<UserDtoResponce>(url);
    }


    public async Task<ResponseModel<UserDtoResponce>> GetUserByNameAsync(string request)
    {
        var url = serviceHandler.CreateConnectionUrlWithQuery(jsonOptions.Value.Url, "api/user/getByName?UserName=", request);

        logger.LogInformation("Отправляем GET запрос в UserService {@url}", url);
        
        return await serviceHandler.GetConnectionHandler<UserDtoResponce>(url);
    }

    public async Task<ResponseModel<UserDtoResponce>> DeleteUserAsync(DeleteUserByIdRequest request)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/delete");
        
        logger.LogInformation("Отправляем POST запрос в UserService {@url}", url);
        
        return await serviceHandler.PostConnectionHandler<DeleteUserByIdRequest, UserDtoResponce>(url, request);
    }

    public async Task<ResponseModel<UserDtoResponce>> UpdateUserAsync(UpdateUserDto request)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/update");
        
        logger.LogInformation("Отправляем POST запрос в UserService {@url}", url);
        
        var result = await serviceHandler.PostConnectionHandler<UpdateUserDto, UserDtoResponce>(url, request);
        return result;
    }

    public async Task<ResponseModel<UserDtoResponce>> CreateUserAsync(CreateUserDto request)
    {
        var url = serviceHandler.CreateConnectionUrlWithoutQuery(jsonOptions.Value.Url, "api/user/create");
        
        logger.LogInformation("Отправляем POST запрос в UserService {@url}", url);
        
        return await serviceHandler.PostConnectionHandler<CreateUserDto, UserDtoResponce>(url, request);
    }
}