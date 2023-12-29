
using Ad.Application.Contracts.Ad;
using Ad.Application.Contracts.File;
using Ad.Infrastructure.Database;
using Ad.Infrastructure.EfCoreDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Infrastructure;

public static class DependencyInjection
{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
   
                services.AddScoped<ITarifRepository, TarifRepository>();
                services.AddScoped<IFileRepository, FileRepository>();
                services.AddScoped<ITagRepository, TagRepository>();
                services.AddScoped<IAdRepository, AdRepository>();
                return services;
        }
}

