using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingService
{
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<BoolResponseDto> CreateBookingAsync(CreateBookingRequestDto dto);
    Task<DateTime[,]> GetBookingDatesAsync(Guid id);
    Task<List<BookingDto>> GetBookingsAsync(Guid id);
}