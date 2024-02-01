using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IDealService
{
    Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto);
    Task<ResponseModel<GetDealResponseDto>> GetDealAsync(GetDealRequestDto dto);
    Task<ResponseModel<List<GetAllDealsResponseDto>>> GetAllDealsAsync(RequestByUserId dto);
}