using Ad.Application.Lib.Contracts.Tarif;
using Ad.Infrastructure.Lib.EfCoreDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Infrastructure.Lib;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services)
    {
        services.AddScoped<ITarifRepository, EfCoreRepository>();
        return services;
    }
}