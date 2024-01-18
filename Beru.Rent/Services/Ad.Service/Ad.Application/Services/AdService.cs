
using Ad.Api.DTO;
using Ad.Application.Contracts.Ad;
using Ad.Application.Contracts.File;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ad.Application.Services;

public class AdService : IAdService
{
    private readonly IAdRepository _repository;
    private readonly IFileRepository _fileRepository;

    public AdService(IAdRepository repository,IFileRepository fileRepository)
    {
        _repository = repository;
        _fileRepository = fileRepository;
    }
    public async Task<BaseApiResponse<Guid>> CreateAdAsync(CreateAdDto ad)
    {
       var result =await _repository.CreateAdAsync(ad.ToDomain());
       return new BaseApiResponse<Guid>(result);
    }

    public async Task<BaseApiResponse<AdDto>> GetAdAsync(Guid id)
    {
        var result = await _repository.GetAdAsync(id);
        if (result != null)
        {
              var data = result.ToDto();
              var files = await _fileRepository.GetAllFilesAsync(id);
              data.Files = files;
              return new BaseApiResponse<AdDto>(data); 
        }
        return new BaseApiResponse<AdDto>(null, "Некорректный id");
    }

    public async Task<BaseApiResponse<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(int page, string sortdate, string sortprice, string cat)
    {
        var result = await _repository.GetAllAdAsync(page,sortdate,sortprice,cat);
        var mainPageDto = new GetMainPageDto<AdMainPageDto>(result.MainPageDto.Select(ad => ad.ToMainPageDto()).ToList(), result.TotalPage);
        return new BaseApiResponse<GetMainPageDto<AdMainPageDto>>(mainPageDto);
    }
}