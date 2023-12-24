using Deal.Api.DTO.Booking;
using Deal.Domain.Models;

namespace Deal.Api.Mapper;

public static class BookingMapper
{
    public static Booking ToDomain(this CreateBookingDto createDealDto)
        => new(createDealDto.AdId, 
                createDealDto.TenantId, 
                createDealDto.Cost);
}