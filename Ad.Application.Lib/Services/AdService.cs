using Ad.Application.Lib.Contracts.Ad;

namespace Ad.Application.Lib.Services;

public class AdService : IAdService
{
    private readonly IAdRepository _adRepository;

    public AdService(IAdRepository adRepository)
    {
        _adRepository = adRepository;
    }

    public Task<bool> CreateAdAsync(Domain.Core.Models.Ad ad)
    {
        return _adRepository.CreateAdAsync(ad);
    }
}