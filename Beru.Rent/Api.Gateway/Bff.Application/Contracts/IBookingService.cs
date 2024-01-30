using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IBookingService
{
    Task<ResponseModel<BoolResponseDto>> CreateBookingAsync(CreateBookingRequestDto dto);

}