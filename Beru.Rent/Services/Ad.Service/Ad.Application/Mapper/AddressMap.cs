using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;

namespace Ad.Application.Mapper;

public static class AddressMap
{
    public static AddressMain ToDomain(this CreateAddressMainDto dto)
    {
        return new AddressMain
        {
            Country = dto.Country,
            City = dto.City,
            Region = dto.Region,
            PostIndex = dto.PostIndex
        };
    }

    public static AddressExtra ToDomain(this CreateAddressExtraDto dto)
    {
        return new AddressExtra
        {
            Street = dto.Street,
            Longitude = dto.Longitude,
            Latitude = dto.Latitude,
            House = dto.House,
            Floor = dto.Floor,
            Apartment = dto.Apartment,
            AddressMainId = dto.AddressMainId
        };
    }
    
    
    public static AddressMainDto ToDto(this AddressMain model)
    {
        return new AddressMainDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            Country = model.Country,
            City = model.City,
            Region = model.Region,
            PostIndex = model.PostIndex
        };
    }

    public static AddressExtraDto ToDto(this AddressExtra model)
    {
        return new AddressExtraDto
        {
            Id = model.Id,
            CreatedAt = model.CreatedAt,
            Street = model.Street,
            Longitude = model.Longitude,
            Latitude = model.Latitude,
            House = model.House,
            Floor = model.Floor,
            Apartment = model.Apartment,
            AddressMainId = model.AddressMainId
        };
    }
    
    public static AddressExtra ToDomain(this AddressExtraDto dto)
    {
        return new AddressExtra
        {
      
            Street = dto.Street,
            Longitude = dto.Longitude,
            Latitude = dto.Latitude,
            House = dto.House,
            Floor = dto.Floor,
            Apartment = dto.Apartment,
            AddressMainId = dto.AddressMainId
        };
    }
}