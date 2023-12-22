using Deal.Application.Contracts.Deal;
using Deal.Domain.Enums;
using Deal.Infrastructure.Persistance;

namespace Deal.Infrastructure.EfCoreDb;

public class EfDealRepository: IDealRepository
{
    private readonly DealContext _db;
    
    public EfDealRepository(DealContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateDealAsync(Domain.Models.Deal deal)
    {
        try
        {
            deal.DealState = DealState.Open.ToString();
            await _db.Deals.AddAsync(deal);
            await _db.SaveChangesAsync();
            return true; 
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}