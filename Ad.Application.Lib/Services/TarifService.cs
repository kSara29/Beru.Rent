using Ad.Application.Lib.Contracts;
using Ad.Application.Lib.Contracts.Tarif;
using Ad.Domain.Core.Models;

namespace Ad.Application.Lib.Services;

public class TarifService : ITarifService
{
    private readonly ITarifRepository _tarifRepository;

    public TarifService(ITarifRepository tarifRepository)
    {
        _tarifRepository = tarifRepository;
    }

    public async Task CreateTarifAsync(Tariff tariff)
    {
        var result = await _tarifRepository.CreateTarifAsync(tariff);
    }
}