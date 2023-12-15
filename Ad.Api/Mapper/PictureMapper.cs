using Ad.Api.DTO;
using Ad.Domain.Core.Models;

namespace Ad.Api.Mapper;

public static class PictureMapper
{
    public static PictureInGallery PictureToModel(this PictureDto dto)
    {
        return new PictureInGallery
        {
            PictureBytes = dto.PictureBytes,
            UserId = dto.UserId,
            AdId = dto.AdId
        };
    }
}