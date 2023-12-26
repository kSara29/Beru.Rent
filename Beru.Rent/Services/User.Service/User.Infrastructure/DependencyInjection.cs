using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Contracts;
using User.Infrastructure.EfCoreDataBase;

namespace User.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection service)
    {
        service.AddScoped<IUserRepository, EfCoreRepository>();
        service.AddTransient<UserManager<Domain.Models.User>>();
        return service;
    }
}