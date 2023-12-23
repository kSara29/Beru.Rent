using Deal.Api.DTO;
using Deal.Domain.Models;

namespace Deal.Api.Mapper;

public static class BookingMap
{
    public static Booking ToDomain(this BookingDto bookingDto)
        => new(
            bookingDto.AdId,
            bookingDto.TenantId,
            bookingDto.Dbeg,
            bookingDto.Dend,
            bookingDto.Cost,
            bookingDto.BookingState
        );
}