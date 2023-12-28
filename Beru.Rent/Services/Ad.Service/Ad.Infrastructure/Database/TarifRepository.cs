

using Ad.Domain.Models;
using Ad.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure.EfCoreDatabase;

public class TarifRepository : ITarifRepository
{
    private readonly AdContext _adContext;

    public TarifRepository(AdContext adContext)
    {
        _adContext = adContext;
    }

    public async Task<Guid> CreateTarifAsync(Tariff tariff)
    {
        await _adContext.Tariffs.AddAsync(tariff);
        await _adContext.SaveChangesAsync();
        return tariff.Id;
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