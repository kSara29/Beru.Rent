namespace Deal.Application.Contracts.Booking;

public interface IBookingRepository
{ 
    Task<bool> CancelReservationAsync(Domain.Models.Booking booking);
    Task<bool> CreateBookingAsync(Domain.Models.Booking booking);
    Task<DateTime[,]> GetAllBookingsAsync(Guid id);
    Task<List<Domain.Models.Booking>> GetBookingsAsync(Guid id);
}