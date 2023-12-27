using Ad.Api.DTO;

namespace Ad.Api.Mapper;

public static class TagMap
{
    public static Tag ToDomain(this TagDto tagDto)
        => new (tagDto.Name, tagDto.AdvertisementId);
}