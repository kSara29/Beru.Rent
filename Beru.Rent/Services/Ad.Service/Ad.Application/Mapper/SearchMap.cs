using Ad.Application.DTO;
using Ad.Domain.Models;

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