using Ad.Application.Contracts.File;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Ad.Dto;
using Ad.Dto.CreateDtos;

namespace Ad.Application.Services;

public class FileService:IFileService
{
    private readonly IFileRepository _repository;

    public FileService(IFileRepository repository)
    {
        _repository = repository;
    }
    public async Task<BaseApiResponse<string>> UploadFileAsync(CreateFileDto dto)
    {
        var result =  await _repository.UploadFileAsync(dto.ToModel(), dto.File);
        return new BaseApiResponse<string>(result.ToString());
    }
    

    public async Task<BaseApiResponse<string>> RemoveFileAsync(Guid id)
    {
        var result =  await _repository.RemoveFileAsync(id);
        return new BaseApiResponse<string>(result);    }

    public async Task<BaseApiResponse<byte[]>> GetFileAsync(Guid id)
    {
        var result =  await _repository.GetFileAsync(id);
        return new BaseApiResponse<byte[]>(result);   
    }
}