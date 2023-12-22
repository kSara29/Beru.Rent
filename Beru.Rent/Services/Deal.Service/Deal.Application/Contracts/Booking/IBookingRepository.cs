namespace Deal.Application.Contracts.Booking;

public interface IBookingRepository
{
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
}