using Microsoft.Extensions.DependencyInjection;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Application.Services;
using User.Application.Validation;

namespace User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<CreateUserValidation>();
        service.AddScoped<UpdateUserValidation>();
        service.AddScoped<PhoneNumberValidation>();
        return service;
    }
}