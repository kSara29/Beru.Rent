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
        


        CreateMainBlocks(modelBuilder);
        Thread.Sleep(10000);
        CreateAd(modelBuilder);
        
        base.OnModelCreating(modelBuilder);
    }

    public void CreateMainBlocks(ModelBuilder modelBuilder)
    {
                modelBuilder.Entity<Category>().HasData(
            new Category{Id=Guid.Parse("62611750-9b02-494a-a58a-3305b7d94596"), CreatedAt = DateTime.Now,Title = "Игрушки" },
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
            new TimeUnit { Id=Guid.Parse("52a09930-e3c0-4400-92d3-e28f8b176a4f"), CreatedAt = DateTime.Now,Title = "Час", Duration = TimeSpan.FromHours(1) },
            new TimeUnit { Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Сутки", Duration = TimeSpan.FromDays(1) },
            new TimeUnit { Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Неделя", Duration = TimeSpan.FromDays(7) },
            new TimeUnit { Id=Guid.NewGuid(), CreatedAt = DateTime.Now,Title = "Месяц", Duration = TimeSpan.FromDays(30) }
        );
        
        modelBuilder.Entity<AddressExtra>().HasData(
                new AddressExtra
                {
                    Id = Guid.Parse("4a4042f8-1621-4653-9bec-87d20cc5fa82"),
                    CreatedAt = DateTime.Now,
                    Country = "Казахстан",
                    City = "Алматы",
                    Region = "Алматы",
                    PostIndex = "S19B5T8",
                    Latitude = "43.232808",
                    Longitude = "76.879196",
                    Street = "улица Каныша Сатпаева",
                    House = "90",
                    Floor = 2,
                    Apartment = "5"
                }
            );
    }

    public void CreateAd(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>().HasData(
            new Advertisement {
                Id = Guid.Parse("83c607b9-228c-43fc-a2b5-84f21e6aea13"),
                UserId = "ecab5681-aa11-4f85-b5d5-72dd1705d767",
                CreatedAt = DateTime.Now,
                Title = "Игрушечный мотоцикл",
                Description = "Достоинства: 1. Хорошая модель мотоцикла; 2. Движущиеся детали; 3. Наличие альтернативной модели; 4. Легко собирается; 5. Понятная инструкция; 6. Запасные части; 7. Оригинальный ЛЕГО; 8. Качественный пластик; 9. Детали хорошо подходят друг к другу; 10. Не маленькая модель; 11. Наклейки. Недостатки: 1. Можно конечно заркала добавить и приборную панель. Хотя и так вполне себе. Комментарий: У мотоцикла поворачивается руль, крутятся колёса, крутится цепь и двигаются цилиндры. Хороший конструктор с движущимися механизмами. Много деталей в наборе. Упакованы в 3 пакетика. Шины лежали без пакета. Запасные детали как всегда в наличии. Стоит на двух колёсах и не падает. Шины из резинового материала",
                ExtraConditions = "нет",
                NeededDeposit = false,
                MinDeposit = null,
                Price = 1400,
                CategoryId = Guid.Parse("62611750-9b02-494a-a58a-3305b7d94596"),
                TimeUnitId =  Guid.Parse("52a09930-e3c0-4400-92d3-e28f8b176a4f"),
                AddressExtraId = Guid.Parse("4a4042f8-1621-4653-9bec-87d20cc5fa82"),
            });
        modelBuilder.Entity<FileModel>().HasData(
            new FileModel
            {
                Id=Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                AdId = Guid.Parse("83c607b9-228c-43fc-a2b5-84f21e6aea13") ,
                MinioFileName = "83c607b9-228c-43fc-a2b5-84f21e6aea13.png" ,
                BucketName = "83c607b9-228c-43fc-a2b5-84f21e6aea13",
                OriginFileName = "83c607b9-228c-43fc-a2b5-84f21e6aea13.png"
            });

    }
    }