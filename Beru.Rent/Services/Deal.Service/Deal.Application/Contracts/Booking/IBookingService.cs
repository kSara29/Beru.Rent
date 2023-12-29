using Deal.Api.DTO;
using Deal.Api.DTO.Booking;

namespace Deal.Application.Contracts.Booking;

public interface IBookingService
{
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<bool> CreateBookingAsync(CreateBookingDto dto);
}