using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto);
    Task<Domain.Models.Deal> GetDealAsync(GetDealRequestDto dto);
    Task<List<Domain.Models.Deal>> GetAllDealsAsync(RequestByUserId id);
    Task<List<Domain.Models.Deal>> GetAllTenantDealsAsync(RequestByUserId id);
}