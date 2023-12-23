namespace Deal.Application.Contracts.Booking;

public interface IBookingRepository
{
 Task<bool> CreateBookingAsync(Domain.Models.Booking booking);
}