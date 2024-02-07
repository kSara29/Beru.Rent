
using Deal.Dto.Booking;

namespace Deal.Application.Mapper;

public static class DealMapper
{
    public static CreateDealResponseDto ToDtoTrue(this Guid id)
        => new(id, true);

    public static CreateDealResponseDto ToDtoFalse(this Guid id)
        => new(id, false);
    
    public static GetDealResponseDto ToDto(this Domain.Models.Deal deal)
        => new(
            deal.Id,
            deal.AdId,
            deal.TenantId,
            deal.Dbeg,
            deal.Dend,
            deal.Cost,
            deal.Deposit,
            deal.ChatId,
            deal.OwnerId,
            "NoOwnerName",
            "NoTenantName"
            );

    public static GetAllDealsResponseDto ToDtoDeals(this Domain.Models.Deal deal)
        => new(
        deal.Id,
        deal.Dbeg,
        deal.Dend,
        deal.Cost
            );
}