
using Ad.Domain.Models;

public interface IAdRepository
{
    Task<bool> ArchiveAsync(Advertisement ad);
   Task<bool> ActivateAsync(Advertisement ad);
    Task<Guid> CreateAdAsync(Advertisement ad);
}