
using Ad.Api.DTO;
using Ad.Application.Responses;

namespace Ad.Application.Services;

public class AdService : IAdService
{
    private readonly IAdRepository _repository;

    public AdService(IAdRepository repository)
    {
        _repository = repository;
    }
    public Task<BaseApiResponse<Guid>> CreateAdAsync(CreateAdDto ad)
    {
        throw new NotImplementedException();
    }
}