using Deal.Api.DTO.Deal;

namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<CreateDealDto> CreateDealAsync(Guid id);
}