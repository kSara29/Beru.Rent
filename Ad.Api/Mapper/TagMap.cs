using Ad.Api.DTO;
using Ad.Domain.Core.Models;

namespace Ad.Api.Mapper;

public static class TagMap
{
    public static Tag ToDomain(this TagDto tagDto)
        => new (tagDto.Name, tagDto.AdvertisementId);
}