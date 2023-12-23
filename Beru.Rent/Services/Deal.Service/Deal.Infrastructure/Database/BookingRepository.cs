using Deal.Application.Contracts.Booking;
using Deal.Domain.Models;

namespace Deal.Infrastructure.Database;

public class BookingRepository : IBookingRepository
{
    public Task<bool> CreateBookingAsync(Booking booking)
    {
        throw new NotImplementedException();
    }
}