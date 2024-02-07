using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IBookingService
{
    Task<ResponseModel<GetBookingResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto);
    Task<ResponseModel<List<GetBookingDatesResponse>>> GetBookingDatesAsync(RequestById dto);
    Task<ResponseModel<GetBookingResponseDto>> GetBookingAsync(RequestById dto);
    Task<ResponseModel<GetDealPagesDto<GetBookingResponseDto>>> GetAllBookingsAsync(GetDealPagesRequestDto dto);
    Task<ResponseModel<GetDealPagesDto<GetBookingResponseDto>>> GetAllTenantBookingsAsync(GetDealPagesRequestDto dto);
}