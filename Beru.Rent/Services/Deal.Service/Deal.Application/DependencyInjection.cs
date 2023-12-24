using Deal.Application.Contracts.Deal;
using Deal.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Deal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection service)
    {
        service.AddScoped<IDealService, DealService>();
        return service;
    }
}