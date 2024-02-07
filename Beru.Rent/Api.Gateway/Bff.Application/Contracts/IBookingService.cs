using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IBookingService
{
    Task<ResponseModel<GetBookingResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto);
    Task<ResponseModel<List<GetBookingDatesResponse>>> GetBookingDatesAsync(RequestById dto);
    Task<ResponseModel<GetBookingResponseDto>> GetBookingAsync(RequestById dto);
    Task<ResponseModel<List<GetBookingResponseDto>>> GetAllBookingsAsync(RequestByUserId dto);
    Task<ResponseModel<List<GetBookingResponseDto>>> GetAllTenantBookingsAsync(RequestByUserId dto);
}