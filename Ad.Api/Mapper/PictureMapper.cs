using Ad.Application.Lib.DTO;
using Ad.Domain.Core.Models;
using Microsoft.AspNetCore.Http;


public static class PictureMapper
{
    public static PictureInGallery PictureToModel(this PictureDto dto)
    {
        return new PictureInGallery
        {
            UserId = dto.UserId,
            AdId = dto.AdId,
            PictureBytes = FileToBytes(dto.PictureFile)
        };
    }

    public static byte[] FileToBytes(this IFormFile file)
    {
        byte[] fileInBytes;
        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            fileInBytes = ms.ToArray();
            string s = Convert.ToBase64String(fileInBytes);
        }
        return fileInBytes;
    }
}