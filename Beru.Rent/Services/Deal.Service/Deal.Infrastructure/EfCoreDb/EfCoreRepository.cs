using Deal.Application.Contracts.Deal;
using Deal.Infrastructure.Persistance;

namespace Deal.Infrastructure.EfCoreDb;

public class EfCoreRepository: IDealRepository
{
    private readonly DealContext _db;
    
    public EfCoreRepository(DealContext db)
    {
        _db = db;
    }
    
    public async Task<bool> CreateDealAsync(Domain.Models.Deal deal)
    {
        try
        {
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