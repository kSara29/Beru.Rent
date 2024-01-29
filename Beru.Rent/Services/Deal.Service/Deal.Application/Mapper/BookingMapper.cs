using Deal.Domain.Models;
using Deal.Dto.Booking;

namespace Deal.Application.Mapper;

public static class BookingMapper
{
    public static Booking ToDomain(this BookingDto dto)
        => new(dto.AdId, 
            dto.TenantId, 
            dto.Cost,
            dto.Dbeg,
            dto.Dend);
    
    public static BoolResponseDto ToDomain(this bool boolean)
        => new(boolean);

    public static BookingDto ToDomain(this Booking booking)
        => new(booking.Id,
            booking.AdId,
            booking.TenantId,
            booking.Dbeg,
            booking.Dend,
            booking.Cost,
            booking.BookingState);
}