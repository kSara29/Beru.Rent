
using Ad.Domain.Models;

namespace Ad.Application.Contracts.Ad;

public interface IAdRepository
{
    Task<bool> ArchiveAsync(Guid id);
    Task<bool> ActivateAsync(Guid id);
    Task<Guid> CreateAdAsync(Advertisement ad);
    Task<Advertisement?> GetAdAsync(Guid id);
}