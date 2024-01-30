using Microsoft.Extensions.DependencyInjection;
using User.Application.Contracts;
using User.Application.Extencions.Validation;
using User.Application.Services;

namespace User.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<CreateUserValidation>();
        return service;
    }
}