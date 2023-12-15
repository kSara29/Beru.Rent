using Ad.Application.Lib.Contracts.Tarif;
using Ad.Domain.Core.Models;
using Ad.Infrastructure.Lib.Context;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> DeleteTarifAsync(Guid tarifId)
    {
        var tariff = await _adContext.Tariffs.FirstOrDefaultAsync(t => t.Id == tarifId);

        if (tariff is null) return false;
        _adContext.Tariffs.Remove(tariff);
        await _adContext.SaveChangesAsync();
        return true;
    }
}