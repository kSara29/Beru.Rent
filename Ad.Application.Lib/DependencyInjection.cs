using Ad.Application.Lib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Application.Lib;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPictureService, PictureService>();
        return services;
    }
}