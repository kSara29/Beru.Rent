namespace Ad.Application.Contracts.Category;

public interface ICategoryRepository
{
    Task<Guid> CreateAsync(Domain.Models.Category entity);
    Task<string> RemoveAsync(Guid id);
    Task<Domain.Models.Category?> GetAsync(Guid id);
    Task<List<Domain.Models.Category?>> GetAllAsync();
}