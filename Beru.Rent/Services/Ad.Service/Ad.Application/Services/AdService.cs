
using Ad.Api.DTO;
using Ad.Application.Contracts.Ad;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Mapper;
using Ad.Application.Responses;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ad.Application.Services;

public class AdService : IAdService
{
    private readonly IAdRepository _repository;

    public AdService(IAdRepository repository)
    {
        _repository = repository;
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
              return new BaseApiResponse<AdDto>(data); 
        }
        return new BaseApiResponse<AdDto>(null, "Некорректный id");
    }

    public async Task<BaseApiResponse<List<AdMainPageDto>>> GetAllAdAsync()
    {
        var result = await _repository.GetAllAdAsync();
        return new BaseApiResponse<List<AdMainPageDto>>(result.Select(ad => ad.ToMainPageDto()).ToList());
    }
}