using Deal.Api.DTO;
using Deal.Api.DTO.Booking;
using Deal.Application.DTO.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingService
{
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<bool> CreateBookingAsync(CreateBookingDto dto);
    Task<DateTime[,]> GetAllBookingsAsync(Guid id);
    Task<List<Domain.Models.Booking>> GetBookingsAsync(Guid id);
}