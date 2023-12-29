using Deal.Api.DTO;
using Deal.Api.DTO.Booking;
using Deal.Domain.Models;

namespace Deal.Api.Mapper;

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
}