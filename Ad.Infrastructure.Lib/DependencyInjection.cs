using Ad.Application.Lib.Contracts.Tarif;
using Ad.Infrastructure.Lib.EfCoreDatabase;
using Ad.Application.Lib.Contracts.Tag;
using Ad.Application.Lib.Services;
using Ad.Infrastructure.Lib.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Ad.Infrastructure.Lib;

public static class DependencyInjection
{ 
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
                services.AddScoped<IPictureRepository, PictureRepository>();
                services.AddScoped<PictureDbContext>();
                services.AddScoped<ITarifRepository, EfCoreRepository>();
                services.AddSingleton<ITagRepository, TagRepository>();
                return services;
        }
    
{
    