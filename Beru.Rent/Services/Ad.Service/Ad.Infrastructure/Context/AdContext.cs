using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.Context;

public class AdContext : DbContext
{
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Advertisement> Ads { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TimeUnit> TimeUnits { get; set; }
    public DbSet<Category> Categories { get; set; }

    public AdContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
}