

public interface ITarifRepository
{
    Task<bool> CreateTarifAsync(Tariff tariff);
    Task<bool> DeleteTarifAsync(Guid tarifId);
}