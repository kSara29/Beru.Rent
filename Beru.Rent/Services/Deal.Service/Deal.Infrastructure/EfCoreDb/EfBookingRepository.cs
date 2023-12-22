using Deal.Application.Contracts.Booking;
using Deal.Domain.Enums;
using Deal.Domain.Models;
using Deal.Infrastructure.Persistance;

namespace Deal.Infrastructure.EfCoreDb;

public class EfBookingRepository: IBookingRepository
{
    private readonly DealContext _db;
    
    public EfBookingRepository(DealContext db)
    {
        _db = db;
    }
    public async Task<bool> CancelReservationAsync(Booking booking)
    {
        try
        {
            booking.BookingState = BookingState.Decline.ToString();
            booking.Dend = DateTime.UtcNow;
            _db.Bookings.Update(booking);
            await _db.SaveChangesAsync();
            return true; 
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}