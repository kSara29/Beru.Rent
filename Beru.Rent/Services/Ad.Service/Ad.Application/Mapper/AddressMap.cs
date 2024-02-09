using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;
using Ad.Dto.RequestDto;

namespace Ad.Application.Mapper;

public static class AddressMap
{
    
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
            Country = dto.Country,
            City = dto.City,
            Region = dto.Region,
            PostIndex = dto.PostIndex
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
            Country = model.Country,
            City = model.City,
            Region = model.Region,
            PostIndex = model.PostIndex
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
            Country = dto.Country,
            City = dto.City,
            Region = dto.Region,
            PostIndex = dto.PostIndex
            
        };
    }
}