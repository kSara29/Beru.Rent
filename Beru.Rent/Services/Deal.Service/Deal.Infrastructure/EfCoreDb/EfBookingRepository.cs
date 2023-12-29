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
            booking.CancelAt = DateTime.UtcNow;
            _db.Bookings.Update(booking);
            await _db.SaveChangesAsync();
            return true; 
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> CreateBookingAsync(Booking booking)
    {
        try
        {
            _db.Bookings.Add(booking);
            await _db.SaveChangesAsync();
            return true; 
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}