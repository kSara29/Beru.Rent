using Ad.Api.DTO;
using Ad.Domain.Core.Models;

namespace Ad.Api.Mapper;

public static class AdMap
{
    public static Domain.Core.Models.Ad ToDomain(this CreateAdDto createAdDto)
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