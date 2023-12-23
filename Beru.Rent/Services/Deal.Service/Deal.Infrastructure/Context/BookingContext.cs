using Deal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Deal.Infrastructure.Context;

public class BookingContext : DbContext
{
    public DbSet<Booking> Bookings { get; set; }
    
    public BookingContext(DbContextOptions options) : base(options)
    {
    }
}