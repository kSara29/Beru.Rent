using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IDealServiceGet
{
    Task<ResponseModel<GetAllBookingDto>> GetAllBookingAsync();
}