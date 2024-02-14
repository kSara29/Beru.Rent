using Common;
using Deal.Dto.Booking;

namespace Bff.Application.Contracts;

public interface IDealService
{
    Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto);
    Task<ResponseModel<GetDealResponseDto>> GetDealAsync(GetDealRequestDto dto);
    Task<ResponseModel<GetDealPagesDto<GetDealResponseDto>>> GetAllDealsAsync(GetDealPagesRequestDto dto);
    Task<ResponseModel<GetDealPagesDto<GetDealResponseDto>>> GetAllTenantDealsAsync(GetDealPagesRequestDto dto);
    Task<ResponseModel<CloseDealResponseDto>> CloseDealAsync(CloseDealRequestDto dto);

}