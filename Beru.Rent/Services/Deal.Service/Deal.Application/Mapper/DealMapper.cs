
using Deal.Dto.Booking;

namespace Deal.Application.Mapper;

public static class DealMapper
{
    public static CreateDealResponseDto ToDto(this Guid id)
        => new(id);
    
    public static GetDealResponseDto ToDto(this Domain.Models.Deal deal)
        => new(
            deal.AdId,
            deal.AdId,
            deal.TenantId,
            deal.Dbeg,
            deal.Dend,
            deal.Cost,
            deal.Deposit,
            deal.ChatId
            );
}