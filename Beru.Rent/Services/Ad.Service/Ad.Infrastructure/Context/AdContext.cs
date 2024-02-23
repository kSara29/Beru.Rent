using System.Net.Mail;
using Ad.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.Context;

public class AdContext : DbContext
{   
    public DbSet<FileModel> Files { get; set; }

    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Advertisement> Ads { get; set; }
    public DbSet<AddressExtra> AddressExtras { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TimeUnit> TimeUnits { get; set; }
    public DbSet<Category> Categories { get; set; }

    public AdContext(DbContextOptions<AdContext> options) : base(options)
    {
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
       // AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<FileModel>()
            .HasOne<Advertisement>(b => b.Ad)
            .WithMany(a => a.Files)
            .HasForeignKey(p=>p.AdId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Category>().HasData(
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Игрушки" },
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Авто"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Инструменты"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Техника"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Электроника"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Фотоаппаратура"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Одежда"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Недвижимость"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Земельный участок"},
            new Category{Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Бьюти-товары"}
        );
        
        modelBuilder.Entity<TimeUnit>().HasData(
            new TimeUnit { Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Час", Duration = TimeSpan.FromHours(1) },
            new TimeUnit { Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Сутки", Duration = TimeSpan.FromDays(1) },
            new TimeUnit { Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Неделя", Duration = TimeSpan.FromDays(7) },
            new TimeUnit { Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Месяц", Duration = TimeSpan.FromDays(30) }
        );
        
        base.OnModelCreating(modelBuilder);
    }
    }