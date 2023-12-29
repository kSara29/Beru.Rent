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
            
        };
    }
    
    public static AdDto ToDto(this Advertisement model)
    {
        return new AdDto
        {
            
        };
    }
}