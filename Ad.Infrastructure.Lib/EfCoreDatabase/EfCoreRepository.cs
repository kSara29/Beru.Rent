using Ad.Application.Lib.Contracts.Tarif;
using Ad.Domain.Core.Models;
using Ad.Infrastructure.Lib.Context;

namespace Ad.Infrastructure.Lib.EfCoreDatabase;

public class EfCoreRepository : ITarifRepository
{
    private readonly AdContext _adContext;

    public EfCoreRepository(AdContext adContext)
    {
        _adContext = adContext;
    }

    public async Task<bool> CreateTarifAsync(Tariff tariff)
    {
        await _adContext.Tariffs.AddAsync(tariff);
        await _adContext.SaveChangesAsync();
        return true;
    }
}