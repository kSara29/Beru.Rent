using Bff.Application.Contracts;
using Bff.Application.Maping;
using Bff.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bff.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<UserServiceMaping>();
        service.AddScoped<IUserService, UserService>();
        return service;
    }
}