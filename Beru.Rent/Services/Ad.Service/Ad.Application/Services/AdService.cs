
using Ad.Api.DTO;
using Ad.Application.Contracts.Ad;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;

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
        throw new NotImplementedException();
    }

    public async Task<BaseApiResponse<AdDto>> GetAdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}