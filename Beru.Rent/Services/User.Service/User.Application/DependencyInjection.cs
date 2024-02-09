using Microsoft.Extensions.DependencyInjection;
using User.Application.Contracts;
using User.Application.Mapper;
using User.Application.Services;
using User.Application.Validation;

namespace User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IResponseMapper, ResponseMapper>();
        service.AddScoped<IUserValidator, ValidationHandler>();
        service.AddScoped<CreateUserValidation>();
        service.AddScoped<UpdateUserValidation>();
        return service;
    }
    
    
}