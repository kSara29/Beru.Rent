using Ad.Application.Contracts.File;
using Ad.Application.Contracts.Tag;
using Ad.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<ITarifService, TarifService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IAdService, AdService>();
        return services;
    }
}