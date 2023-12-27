using Ad.Api.DTO;

namespace Ad.Api.Mapper;

public static class AdMap
{
    public static Advertisement ToDomain(this CreateAdDto createAdDto)
        => new(
            createAdDto.UserId, 
            createAdDto.Title, 
            createAdDto.Description,
            createAdDto.ExtraConditions,
            createAdDto.Deposit,
            createAdDto.MinDeposit,
            createAdDto.Price,
            createAdDto.CategoryId,
            createAdDto.TimeUnitId,
            createAdDto.ContractTypeId,
            createAdDto.AddressExtraId
            );
}