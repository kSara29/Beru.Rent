using Deal.Dto.Deal;

namespace Deal.Application.Contracts.Deal;

public interface IDealService
{
    Task<CreateDealDto> CreateDealAsync(Guid id);
}