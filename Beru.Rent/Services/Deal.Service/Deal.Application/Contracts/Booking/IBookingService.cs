namespace Deal.Application.Contracts.Booking;

public interface IBookingService
{
    Task<bool> CreateBookingAsync(Domain.Models.Booking booking);
}