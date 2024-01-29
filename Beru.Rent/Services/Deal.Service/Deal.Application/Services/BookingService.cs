using Deal.Application.Contracts.Booking;
using Deal.Application.Mapper;
using Deal.Domain.Models;
using Deal.Dto.Booking;

namespace Deal.Application.Services;

public class BookingService: IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }   

    public async Task<bool> CancelReservationAsync(Booking booking)
    {
        return await (_bookingRepository.CancelReservationAsync(booking));
    }

    public async Task<BoolResponseDto> CreateBookingAsync(CreateBookingRequestDto dto)
    {
        bool boolean = await _bookingRepository.CreateBookingAsync(dto);
        return boolean.ToDomain();
    }

    public async Task<DateTime[,]> GetBookingDatesAsync(Guid id)
    {
        return await _bookingRepository.GetBookingDatesAsync(id);
    }

    public async Task<List<BookingDto>> GetBookingsAsync(Guid id)
    {
        return await _bookingRepository.GetBookingsAsync(id);
    }
}