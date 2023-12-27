using Ad.Api.DTO;
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
}