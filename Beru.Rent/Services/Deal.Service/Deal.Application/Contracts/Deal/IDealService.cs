using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Deal;

public interface IDealService
{
    Task<CreateDealResponseDto> CreateDealAsync(CreateDealRequestDto dto);
    Task<ResponseModel<GetDealResponseDto>> GetDealAsync(GetDealRequestDto dto);
    Task<ResponseModel<List<GetAllDealsResponseDto>>> GetAllDealsAsync(RequestByUserId id);
    Task<ResponseModel<List<GetAllDealsResponseDto>>> GetAllTenantDealsAsync(RequestByUserId id);
}