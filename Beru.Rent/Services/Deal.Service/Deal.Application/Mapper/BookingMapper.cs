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
    
    public static Booking ToDomain(this CreateBookingDto dto)
        => new(dto.AdId, 
            dto.TenantId, 
            dto.Cost,
            dto.Dbeg,
            dto.Dend);
    public static Booking ToDomain(this GetAllBookingDto dto)
        => new(
            dto.AdId
            );
}