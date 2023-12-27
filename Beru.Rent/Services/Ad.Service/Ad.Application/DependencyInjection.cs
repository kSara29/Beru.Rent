using Ad.Application.Contracts.Tag;
using Ad.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<ITarifService, TarifService>();
        services.AddSingleton<ITagService, TagService>();
        services.AddSingleton<IAdService, AdService>();
        return services;
    }
}