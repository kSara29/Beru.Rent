using Deal.Application.Contracts.Deal;
using Deal.Application.Mapper;
using Deal.Dto.Booking;

namespace Deal.Application.Services;

public class DealService: IDealService
{
    private readonly IDealRepository _dealRepository;
    
    public DealService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }

    public async Task<CreateDealResponseDto> CreateDealAsync(CreateDealRequestDto dto)
    {
        var res = await _dealRepository.CreateDealAsync(dto);
         return res.ToDomain();
    }
}