using Deal.Dto.Booking;
using Deal.Dto.Deal;

namespace Deal.Application.Contracts.Deal;

public interface IDealRepository
{
    Task<bool> CreateDealAsync(CreateDealRequestDto dto);
}