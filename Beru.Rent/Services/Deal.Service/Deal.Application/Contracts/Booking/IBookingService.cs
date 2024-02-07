using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingService
{
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<ResponseModel<GetBookingResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto);
    Task<List<GetBookingDatesResponse>> GetBookingDatesAsync(RequestById id);
    Task<List<GetBookingResponseDto>> GetAllBookingsAsync(RequestByUserId id);
    Task<GetBookingResponseDto> GetBookingAsync(RequestById id);
    Task<List<GetBookingResponseDto>> GetAllTenantBookingsAsync(RequestByUserId id);
}