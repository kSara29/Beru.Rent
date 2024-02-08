using Deal.Domain.Models;
using Deal.Dto.Booking;

namespace Deal.Application.Mapper;

public static class BookingMapper
{
    public static Booking ToDomain(this CreateBookingRequestDto dto)
        => new(dto.AdId, 
            dto.TenantId,
            dto.Cost,
            dto.Dbeg,
            dto.Dend,
            dto.OwnerId);
    
    public static BoolResponseDto ToDto(this bool boolean)
        => new(boolean);

    public static GetBookingDatesResponse ToDateDto(this Booking booking)
        => new(
            booking.Dbeg,
            booking.Dend
            );
    
    public static GetAllBookingsResponseDto ToDtoes(this Booking booking)
        => new(
            booking.Id,
            booking.Dbeg,
            booking.Dend,
            booking.Cost
        );

    public static GetBookingResponseDto ToDto(this Booking booking)
    {
        return new GetBookingResponseDto()
        {
            Id = booking.Id,
            AdId = booking.AdId,
            TenantId = booking.TenantId,
            Dbeg = booking.Dbeg,
            Dend = booking.Dend,
            Cost = booking.Cost,
            BookingState = booking.BookingState,
            OwnerId = booking.OwnerId,
            OwnerName = "NoOwnerName",
            TenantName = "NoTenantName"
        };
    }
}