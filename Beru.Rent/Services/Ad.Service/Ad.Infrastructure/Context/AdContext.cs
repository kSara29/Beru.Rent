using System.Net.Mail;
using Ad.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.Context;

public class AdContext : DbContext
{
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Advertisement> Ads { get; set; }
    public DbSet<AddressMain> AddressMains { get; set; }
    public DbSet<AddressExtra> AddressExtras { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TimeUnit> TimeUnits { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<FileModel> Files { get; set; }

    public AdContext(DbContextOptions options) : base(options)
    {
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
       // AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    
    
}