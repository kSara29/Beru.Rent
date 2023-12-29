
using Ad.Domain.Models;

namespace Ad.Application.Contracts.Ad;

public interface IAdRepository
{
    Task<bool> ArchiveAsync(Advertisement ad);
    Task<bool> ActivateAsync(Advertisement ad);
    Task<Guid> CreateAdAsync(Advertisement ad);
    Task<Advertisement> GetAdAsync(Guid id);
}