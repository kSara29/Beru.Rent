namespace Ad.Application.Contracts.TimeUnit;

public interface ITimeUnitRepository
{
    Task<Guid> CreateAsync(Domain.Models.TimeUnit entity);
    Task<string> RemoveAsync(Guid id);
    Task<Domain.Models.TimeUnit?> GetAsync(Guid id);
    Task<List<Domain.Models.TimeUnit?>> GetAllAsync();
}