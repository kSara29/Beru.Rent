using Ad.Application.Lib.Contracts.Tarif;
using Ad.Infrastructure.Lib.EfCoreDatabase;
using Ad.Application.Lib.Contracts.Tag;
using Ad.Infrastructure.Lib.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Infrastructure.Lib;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<ITarifRepository, EfCoreRepository>();
        services.AddSingleton<ITagRepository, TagRepository>();
        return services;
    }
}