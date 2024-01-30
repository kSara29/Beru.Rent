using Common;
using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<Guid> CreateDealAsync(CreateDealRequestDto dto);
    Task<Domain.Models.Deal> GetDealAsync(GetDealRequestDto dto);
    Task<List<Domain.Models.Deal>> GetAllDealsAsync(RequestByUserId id);
}