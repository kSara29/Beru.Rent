using Ad.Application.Lib.Services;
using Ad.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.Lib.Database;

public class PictureDbContext :DbContext
{
    public DbSet<PictureInGallery> Pictures { get; set; }
    
    public PictureDbContext(DbContextOptions<PictureDbContext> options) :base(options)
    {

        
    }
}