using Ad.Application.DTO.GetDtos;
using Ad.Application.Responses;
using Ad.Domain.Models;
using Ad.Dto;
using Ad.Dto.GetDtos;
using Ad.Dto.ResponseDto;
using Common;
using CreateAdDto = Ad.Dto.CreateDtos.CreateAdDto;

namespace Ad.Application.Contracts.Ad;

public interface IAdService
{
    Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad);
    Task<ResponseModel<AdDto>> GetAdAsync(Guid id);
    Task<ResponseModel<List<AdDto>>> GetAdsByUserId(Guid userId);
    Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(int page, string sortdate, string sortprice, string cat);
    Task<ResponseModel<DecimalResponse>> GetCostAsync(Guid adId, DateTime ebeg, DateTime dend);
    
}