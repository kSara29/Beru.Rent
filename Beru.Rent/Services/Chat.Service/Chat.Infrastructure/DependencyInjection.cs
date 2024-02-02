using Chat.Application.Contracts;
using Chat.Infrastructure.Context;
using Chat.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Chat.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbContext>(serviceProvider =>
        {
            var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
            var database = mongoClient.GetDatabase("ChatService");
            return new MongoDbContext(database);
        });
        
        services.AddScoped<IChatRepository, ChatRepository>();
        return services;
    }
}