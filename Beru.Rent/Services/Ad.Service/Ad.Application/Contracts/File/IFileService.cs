using Ad.Application.Responses;
using Ad.Dto;
using Ad.Dto.CreateDtos;

namespace Ad.Application.Contracts.File;

public interface IFileService
{
    Task<BaseApiResponse<string>> UploadFileAsync(CreateFileDto dto);
    Task<BaseApiResponse<string>> RemoveFileAsync(Guid id);
    Task<BaseApiResponse<byte[]>> GetFileAsync(Guid id);
}