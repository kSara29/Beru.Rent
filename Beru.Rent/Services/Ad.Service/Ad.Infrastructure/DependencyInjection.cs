
using Ad.Infrastructure.Database;
using Ad.Infrastructure.EfCoreDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Infrastructure;

public static class DependencyInjection
{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
   
                services.AddScoped<ITarifRepository, TarifRepository>();
                services.AddSingleton<ITagRepository, TagRepository>();
                services.AddSingleton<IAdRepository, AdRepository>();
                return services;
        }
}

