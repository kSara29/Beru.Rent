using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingRepository
{ 
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<bool> CreateBookingAsync(CreateBookingRequestDto dto);
    
    Task<List<Domain.Models.Booking>> GetBookingDatesAsync(RequestById id);
    Task<List<Domain.Models.Booking>> GetAllBookingsAsync(List<GetAllBookingsRequestDto> id);
    Task<Domain.Models.Booking> GetBookingAsync(RequestById id);
}