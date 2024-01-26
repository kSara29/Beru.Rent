

using Ad.Api.DTO;
using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;
using Ad.Domain.Models;

public interface IAdService
{
    Task<BaseApiResponse<Guid>> CreateAdAsync(CreateAdDto ad);
    Task<BaseApiResponse<AdDto>> GetAdAsync(Guid id);
    Task<BaseApiResponse<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(int page, string sortdate, string sortprice, string cat);
    Task<decimal> GetCostAsync(Guid adId, DateTime ebeg, DateTime dend);
}