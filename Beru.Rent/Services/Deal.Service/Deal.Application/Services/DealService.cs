using Deal.Application.Contracts.Deal;

namespace Deal.Application.Services;

public class DealService: IDealService
{
    private readonly IDealRepository _dealRepository;
    
    public DealService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository;
    }
    
    public Task<bool> CreateDealAsync(Domain.Models.Deal deal)
    {
        return (_dealRepository.CreateDealAsync(deal)); 
    }
}