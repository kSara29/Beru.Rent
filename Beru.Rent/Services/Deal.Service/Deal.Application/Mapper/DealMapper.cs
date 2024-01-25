using Deal.Dto.Deal;

namespace Deal.Api.Mapper;

public static class DealMapper
{
    public static Domain.Models.Deal ToDomain(this CreateDealDto createDealDto)
        => new(createDealDto.AdId, createDealDto.TenantId, createDealDto.Cost, createDealDto.OwnerId, createDealDto.DealState, createDealDto.Deposit);
}