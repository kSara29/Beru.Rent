using System.Reflection;
using Deal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Deal.Infrastructure.Persistance;

public class DealContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Domain.Models.Deal> Deals { get; set; }
    public DbSet<ContractStorage> ContractStorages { get; set; }
    
    
    public DealContext(DbContextOptions options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
}