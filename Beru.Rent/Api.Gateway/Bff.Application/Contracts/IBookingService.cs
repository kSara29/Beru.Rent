using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IBookingService
{
    Task<ResponseModel<BoolResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto);
    Task<ResponseModel<List<GetBookingDatesResponse>>> GetBookingDatesAsync(RequestById dto);
    Task<ResponseModel<GetBookingResponseDto>> GetBookingAsync(RequestById dto);
    Task<ResponseModel<List<GetAllBookingsResponseDto>>> GetAllBookingsAsync(RequestByUserId dto);
}