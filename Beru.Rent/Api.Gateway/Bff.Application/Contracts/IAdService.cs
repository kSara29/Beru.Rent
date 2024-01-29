using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.CreateDtos;
using Ad.Dto.GetDtos;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface IAdService
{
    Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad);
    Task<ResponseModel<AdDto>> GetAdAsync(RequestById id);

    Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(int page, string sortdate, string sortprice,
        string cat);

    Task<decimal> GetCostAsync(RequestById adId, DateTime ebeg, DateTime dend);
    Task<StringResponse> GetOwnerIdAsync(RequestById adId);

}
