using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingService
{
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<bool> CreateBookingAsync(CreateBookingDto dto);
    Task<DateTime[,]> GetAllBookingsAsync(Guid id);
    Task<List<BookingDto>> GetBookingsAsync(Guid id);
}