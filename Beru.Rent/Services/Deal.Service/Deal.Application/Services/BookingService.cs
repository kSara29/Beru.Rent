using Deal.Application.Contracts.Booking;
using Deal.Domain.Models;

namespace Deal.Application.Services;

public class BookingService: IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public Task<bool> CreateBookingAsync(Booking booking)
    {
        return _bookingRepository.CreateBookingAsync(booking);
    }
}