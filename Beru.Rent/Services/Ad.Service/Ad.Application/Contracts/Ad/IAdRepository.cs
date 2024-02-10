
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;
using Deal.Dto.Booking;

namespace Ad.Application.Contracts.Ad;

public interface IAdRepository
{
    Task<bool> ArchiveAsync(Guid id);
    Task<bool> ActivateAsync(Guid id);
    Task<Guid> CreateAdAsync(Advertisement ad);
    Task<Advertisement?> GetAdAsync(Guid id);
    Task<List<Advertisement>?> GetAdsByUserId(Guid userId);  
    Task<GetMainPageDto<Advertisement>?> GetAllAdAsync(int page, string sortdate, string sortprice, string cat);
    Task<GetMainPageDto<Advertisement>?> GetAllFindAdAsync(int page, string sortdate, string sortprice, string cat, string finder);
    Task<decimal> GetCostAsync(CreateBookingRequestDto dto);
  
}