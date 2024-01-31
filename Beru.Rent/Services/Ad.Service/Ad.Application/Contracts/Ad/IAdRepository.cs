
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;

namespace Ad.Application.Contracts.Ad;

public interface IAdRepository
{
    Task<bool> ArchiveAsync(Guid id);
    Task<bool> ActivateAsync(Guid id);
    Task<Guid> CreateAdAsync(Advertisement ad);
    Task<Advertisement?> GetAdAsync(Guid id);
    Task<List<Advertisement>?> GetAdsByUserId(Guid userId);  
    Task<GetMainPageDto<Advertisement>?> GetAllAdAsync(int page, string sortdate, string sortprice, string cat);
    Task<decimal> GetCostAsync(Guid adId, DateTime ebeg, DateTime dend);
  
}