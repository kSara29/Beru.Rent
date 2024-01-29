using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IDealServiceCreate
{
    Task<ResponseModel<BookingDto>> CreateBookingAsync(CreateBookingRequestDto request);
}