using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace DbMigrator;

public static class DatabaseMigrationHelper
{
    public static async Task<IServiceProvider> ApplyMigrations<TContext>(this IServiceProvider serviceProvider, byte? retryValue = 0)
        where TContext : DbContext
    {
        try
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var dbContext = services.GetRequiredService<TContext>();
            await dbContext.Database.MigrateAsync();
            return serviceProvider;
        }
        catch (NpgsqlException)
        {
            if (retryValue < 11)
            {
                retryValue++;
                await Task.Delay(2000);
                await serviceProvider.ApplyMigrations<TContext>(retryValue);
            }
        }

        return serviceProvider;
    }
}
