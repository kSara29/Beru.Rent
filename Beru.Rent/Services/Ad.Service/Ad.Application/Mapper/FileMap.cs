using Ad.Domain.Models;
using Ad.Dto;
using Ad.Dto.CreateDtos;

namespace Ad.Application.Mapper;

public static class FileMap
{
    public static FileModel ToModel(this CreateFileDto dto)
    {
        return new FileModel
        {
            OriginFileName = dto.File.FileName,
            CreatedAt = DateTime.Now,
            AdId = dto.AdId,
            BucketName = dto.AdId.ToString()
        };
    }
}