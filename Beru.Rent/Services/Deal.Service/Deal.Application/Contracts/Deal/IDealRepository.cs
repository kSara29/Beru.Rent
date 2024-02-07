using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<Dictionary<bool, Guid>> CreateDealAsync(CreateDealRequestDto dto);
    Task<Domain.Models.Deal> GetDealAsync(GetDealRequestDto dto);
    Task<GetDealPagesDto<Domain.Models.Deal>> GetAllDealsAsync(GetDealPagesRequestDto dto);
    Task<GetDealPagesDto<Domain.Models.Deal>> GetAllTenantDealsAsync(GetDealPagesRequestDto dto);
}