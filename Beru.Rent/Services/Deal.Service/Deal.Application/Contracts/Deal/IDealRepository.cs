using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto);
    Task<ResponseModel<CreateDealResponseDto>> UpdateDealAsync(Guid chatId, Guid dealId); 
    Task<Domain.Models.Deal> GetDealAsync(GetDealRequestDto dto);
    Task<GetDealPagesDto<Domain.Models.Deal>> GetAllDealsAsync(GetDealPagesRequestDto dto);
    Task<GetDealPagesDto<Domain.Models.Deal>> GetAllTenantDealsAsync(GetDealPagesRequestDto dto);
    Task<bool> CloseDealAsync(CloseDealRequestDto dto);

}