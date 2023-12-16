using Ad.Domain.Core.Models;
namespace Ad.Application.Lib.Contracts.Ad;

public interface IAdService
{
    Task<bool> CreateAdAsync(Domain.Core.Models.Ad ad);
}