using Ad.Domain.Models;
using Ad.Dto;

namespace Ad.Application.Mapper;

public static class SearchMap
{
    public static List<Advertisement> ToDomain(this SearchDto searchDto)
    {
        return new List<Advertisement>
        {
            
        };
    }
}