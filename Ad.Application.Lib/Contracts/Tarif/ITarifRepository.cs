using Ad.Domain.Core.Models;

namespace Ad.Application.Lib.Contracts.Tarif;

public interface ITarifRepository
{
    Task<bool> CreateTarifAsync(Tariff tariff);
    Task<bool> DeleteTarifAsync(Guid tarifId);
}