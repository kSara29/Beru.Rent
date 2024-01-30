using Deal.Dto.Booking;

namespace Deal.Application.Contracts.Deal;

public interface IDealService
{
    Task<CreateDealResponseDto> CreateDealAsync(CreateDealRequestDto dto);
}