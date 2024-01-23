using Ad.Domain.Models;

namespace Ad.Application.Contracts.Address;

public interface IAddressRepository<T>
{
    Task<Guid> CreateAsync(T entity);
    Task<string> RemoveAsync(Guid id);
    Task<T?> GetAsync(Guid id);

}