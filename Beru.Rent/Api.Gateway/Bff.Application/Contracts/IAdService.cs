using Ad.Application.DTO.CreateDtos;
using Ad.Application.DTO.GetDtos;
using Ad.Dto.CreateDtos;
using Ad.Dto.GetDtos;
using Ad.Dto.RequestDto;
using Ad.Dto.ResponseDto;
using Common;

namespace Bff.Application.Contracts;

public interface IAdService
{
    Task<ResponseModel<GuidResponse>> CreateAdAsync(CreateAdDto ad);
    Task<ResponseModel<AdDto>> GetAdAsync(RequestById id);
    Task<ResponseModel<List<AdDto>>> GetAdsByUserIdAsync(RequestById id);

    Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllAdAsync(MainPageRequestDto requestDto);
    Task<ResponseModel<GetMainPageDto<AdMainPageDto>>> GetAllFindAdAsync(FindMainPageRequestDto requestDto);

    Task<ResponseModel<DecimalResponse>> GetCostAsync(RequestById adId, DateTime ebeg, DateTime dend);

}
