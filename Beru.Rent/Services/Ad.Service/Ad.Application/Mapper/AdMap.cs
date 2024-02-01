using Ad.Application.DTO.GetDtos;
using Ad.Domain.Enums;
using Ad.Domain.Models;
using Ad.Dto;
using Ad.Dto.GetDtos;
using CreateAdDto = Ad.Dto.CreateDtos.CreateAdDto;

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
            TimeUnitId = model.TimeUnitId,
            ContractType = model.ContractType,
            AddressExtraId = model.AddressExtraId,
            Category = model.Category,
            AddressExtra = model.AddressExtra,
            TimeUnit = model.TimeUnit
        };
    }

    public static AdMainPageDto ToMainPageDto(this Advertisement model)
    {
        return new AdMainPageDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            UserId = Guid.Parse(model.UserId),
            Title = model.Title,
            Description = model.Description,
            State = model.State,
            Price = model.Price,
            CategoryId = model.CategoryId,
            TimeUnitId = model.TimeUnitId,
            TimeUnit = model.TimeUnit.Title,
            Street = model.AddressExtra.Street,
            City = model.AddressExtra.City,
            Category = model.Category.Title
        };
    }
}