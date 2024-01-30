using Deal.Dto.Booking;
using Deal.Dto.Deal;

namespace Deal.Application.Contracts.Deal;

public interface IDealService
{
    Task<BoolResponseDto> CreateDealAsync(CreateDealRequestDto dto);
}