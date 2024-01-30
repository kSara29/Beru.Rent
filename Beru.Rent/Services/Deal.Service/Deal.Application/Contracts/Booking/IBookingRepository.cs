using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingRepository
{ 
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<bool> CreateBookingAsync(CreateBookingRequestDto dto);
    
    Task<List<GetBookingDatesResponse>> GetBookingDatesAsync(RequestById id);
    Task<List<BookingDto>> GetBookingsAsync(Guid id);
}