using Ad.Api.DTO;
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;

namespace Ad.Application.Mapper;

public static class AdMap
{

    public static Advertisement ToDomain(this CreateAdDto createAdDto)
    {
        return new Advertisement
        {
            UserId = createAdDto.UserId,
            Title = createAdDto.Title,
            Description = createAdDto.Description,
            ExtraConditions = createAdDto.ExtraConditions,
            NeededDeposit = createAdDto.NeededDeposit,
            MinDeposit = createAdDto.MinDeposit,
            Price = createAdDto.Price,
            CategoryId = createAdDto.CategoryId,
            TimeUnitId = createAdDto.TimeUnitId,
            ContractType = (ContractType)createAdDto.ContractType,
            AddressExtraId = createAdDto.AddressExtraId
        };
    }
    
    public static AdDto ToDto(this Advertisement model)
    {
        return new AdDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UserId = model.Id,
            Title = model.Title,
            Description = model.Description,
            ExtraConditions = model.ExtraConditions,
            NeededDeposit = model.NeededDeposit,
            MinDeposit = model.MinDeposit,
            State = model.State,
            Price = model.Price,
            UpdatedAt = model.UpdatedAt,
            CategoryId = model.CategoryId,
            Category = model.Category,
            TimeUnitId = model.TimeUnitId,
            TimeUnit = model.TimeUnit,
            ContractType = model.ContractType,
            AddressExtraId = model.AddressExtraId,
            AddressExtra = model.AddressExtra,
            AddressMain = model.AddressExtra.AddressMain
        };
    }
}