
using Ad.Application.Contracts.Ad;
using Ad.Application.Contracts.Address;
using Ad.Application.Contracts.Category;
using Ad.Application.Contracts.File;
using Ad.Application.Contracts.TimeUnit;
using Ad.Domain.Models;
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
                services.AddScoped<IAddressRepository<AddressExtra>, AddressExtraRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddScoped<ITimeUnitRepository, TimeUnitRepository>();
                return services;
        }
}

