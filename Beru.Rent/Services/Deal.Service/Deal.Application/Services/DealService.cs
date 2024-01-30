using Deal.Application.Contracts.Deal;
using Deal.Application.Mapper;
using Deal.Dto.Booking;
using Deal.Dto.Deal;

namespace Deal.Application.Services;

public class DealService: IDealService
{
    private readonly IDealRepository _dealRepository;
    
    public DealService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }

    public async Task<BoolResponseDto> CreateDealAsync(CreateDealRequestDto dto)
    {
        bool boolean = await _dealRepository.CreateDealAsync(dto);
        return boolean.ToDomain();
    }
}