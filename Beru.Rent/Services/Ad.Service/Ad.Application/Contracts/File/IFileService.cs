using Ad.Application.Responses;
using Ad.Dto;
using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Contracts.File;

public interface IFileService
{
    Task<ResponseModel<StringResponse>> UploadFileAsync(CreateFileDto dto);
    Task<ResponseModel<StringResponse>> RemoveFileAsync(Guid id);
    Task <ResponseModel<byte[]?>> GetFileAsync(Guid id);
}