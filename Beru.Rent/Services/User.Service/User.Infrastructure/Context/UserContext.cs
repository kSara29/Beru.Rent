using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.Domain.Models;

namespace User.Infrastructure.Context;

public class UserContext: IdentityDbContext<Domain.Models.User>
{
    public DbSet<Domain.Models.User> Users { get; set; }
    public DbSet<Image> Images { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Domain.Models.User>()
            .HasOne(u => u.UserAvatar)
            .WithOne(i => i.User)
            .HasForeignKey<Image>(i => i.UserId);
    }
}