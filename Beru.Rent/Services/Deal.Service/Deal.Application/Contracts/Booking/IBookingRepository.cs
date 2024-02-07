using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingRepository
{ 
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<Dictionary<bool, Domain.Models.Booking>> CreateBookingAsync(CreateBookingRequestDto dto);
    
    Task<List<Domain.Models.Booking>> GetBookingDatesAsync(RequestById id);
    Task<GetDealPagesDto<Domain.Models.Booking>> GetAllBookingsAsync(GetDealPagesRequestDto id);
    Task<Domain.Models.Booking> GetBookingAsync(RequestById id);
    Task<GetDealPagesDto<Domain.Models.Booking>> GetAllTenantBookingsAsync(GetDealPagesRequestDto id);
}