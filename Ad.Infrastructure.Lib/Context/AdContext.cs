using Ad.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.Lib.Context;

public class AdContext : DbContext
{
    public DbSet<Tariff> Tariffs { get; set; }
    
    public AdContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
}