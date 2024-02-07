using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DbMigrator;

    public static class DatabaseMigrationHelper
    {
        // public static void ApplyMigrations<TContext>(this IServiceProvider serviceProvider)
        //     where TContext : DbContext
        // {
        //     try
        //     {
        //         Thread.Sleep(15000);
        //         var dbContext = serviceProvider.GetRequiredService<TContext>();
        //         dbContext.Database.Migrate();
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex);
        //     }
        // }
    }
