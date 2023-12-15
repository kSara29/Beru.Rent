using Ad.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.Lib.Database;

public class PictureDbContext :DbContext
{
    public DbSet<PictureInGallery> Pictures { get; set; }
}