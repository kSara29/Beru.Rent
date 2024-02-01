using Ad.Dto.CreateDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface IFileService
{
    Task<ResponseModel<StringResponse>> UploadFileAsync(CreateFileDto dto);
    Task<ResponseModel<StringResponse>> RemoveFileAsync(RequestById id);
    Task<ResponseModel<byte[]>> GetFileAsync(RequestById id);
}