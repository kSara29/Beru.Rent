

using Ad.Domain.Models;

public interface ITarifRepository
{
    Task<Guid> CreateTarifAsync(Tariff tariff);
    Task<bool> DeleteTarifAsync(Guid tarifId);
}