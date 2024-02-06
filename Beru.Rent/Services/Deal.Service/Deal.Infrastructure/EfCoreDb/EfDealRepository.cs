using Common;
using Deal.Application.Contracts.Deal;
using Deal.Domain.Enums;
using Deal.Domain.Models;
using Deal.Dto.Booking;
using Deal.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Deal.Infrastructure.EfCoreDb;

public class EfDealRepository: IDealRepository
{
    private readonly DealContext _db;

    public EfDealRepository(DealContext db)
    {
        _db = db;
    }

    public async Task<Dictionary<bool, Guid>> CreateDealAsync(CreateDealRequestDto dto)
    {
            Booking? book = await _db.Bookings.FirstOrDefaultAsync(b => b.Id == dto.bookingId);
            if (dto.isApproved)
            {
                Domain.Models.Deal deal = new Domain.Models.Deal(
                    book.AdId,
                    book.TenantId,
                    book.Cost,
                    dto.ownerId,
                    book.Dbeg,
                    book.Dend,
                    book.Id
                );
                
                deal.DealState = DealState.Open.ToString();
                book.BookingState = BookingState.Accept.ToString();
                _db.Deals.Add(deal);
                _db.SaveChanges();
                Dictionary<bool, Guid> trueres = new Dictionary<bool, Guid>() {[true] = deal.Id };
                return trueres;
            }
            else
            {
                book.BookingState = BookingState.Decline.ToString();
                _db.SaveChanges();
                Domain.Models.Deal deal = new Domain.Models.Deal();
                Dictionary<bool, Guid> falseres = new Dictionary<bool, Guid>() {[false] = deal.Id };
                return falseres;
            }
            
    }

    public async Task<Domain.Models.Deal> GetDealAsync(GetDealRequestDto dto)
    {
        try
        {
            return await _db.Deals.FirstOrDefaultAsync(d => d.Id == dto.dealId);
        }
        catch (Exception e)
        {
            return new Domain.Models.Deal();
        }
        
    }

    public async Task<List<Domain.Models.Deal>> GetAllDealsAsync(RequestByUserId id)
    {
        return await _db.Deals.Where(d => d.OwnerId == id.Id).ToListAsync();
    }
    
    public async Task<List<Domain.Models.Deal>> GetAllTenantDealsAsync(RequestByUserId id)
    {
        return await _db.Deals.Where(d => d.TenantId == id.Id).ToListAsync();
    }
}