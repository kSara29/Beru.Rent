using Ad.Application.Contracts.File;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Ad.Dto;
using Ad.Dto.CreateDtos;
using Ad.Dto.GetDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Ad.Application.Services;

public class FileService(IFileRepository repository) : IFileService
{
    public async Task<ResponseModel<StringResponse>> UploadFileAsync(CreateFileDto dto)
    {
        var result =  await repository.UploadFileAsync(dto.ToModel(), dto.File);
        var response = new StringResponse
        {
            Text = result.ToString()
        };
        return ResponseModel<StringResponse>.CreateSuccess(response);
    }

    public async Task<ResponseModel<StringResponse>> RemoveFileAsync(Guid id)
    {
        var result =  await repository.RemoveFileAsync(id);
        var response = new StringResponse
        {
            Text = result
        };
        return ResponseModel<StringResponse>.CreateSuccess(response);
    }

    public async Task<ResponseModel<byte[]?>> GetFileAsync(Guid id)
    {
        var result =  await repository.GetFileAsync(id);
      
        if (result != null)
        {
             return ResponseModel<byte[]?>.CreateSuccess(result);   
        }
        var errors = new List<ResponseError>();
        var errorModel = new ResponseError
        {
            Code = "404",
            Message = "Такой файл не найден"
        };
        errors.Add(errorModel);
        return ResponseModel<byte[]?>.CreateFailed(errors);  
        
        
    }
}