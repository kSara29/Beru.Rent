
using Deal.Dto.Booking;

namespace Deal.Application.Mapper;

public static class DealMapper
{
    public static CreateDealResponseDto ToDomain(this Guid id)
        => new(id);
}