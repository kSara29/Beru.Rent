using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<Guid> CreateDealAsync(CreateDealRequestDto dto);
}