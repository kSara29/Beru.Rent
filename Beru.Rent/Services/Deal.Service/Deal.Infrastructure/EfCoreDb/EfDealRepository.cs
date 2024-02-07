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
            Booking? book = await _db.Bookings.FirstOrDefaultAsync(b => b.Id == dto.BookingId);
            if (dto.IsApproved)
            {
                Domain.Models.Deal deal = new Domain.Models.Deal(
                    book.AdId,
                    book.TenantId,
                    book.Cost,
                    dto.OwnerId,
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
            return await _db.Deals.FirstOrDefaultAsync(d => d.Id == dto.DealId);
        }
        catch (Exception e)
        {
            return new Domain.Models.Deal();
        }
        
    }

    public async Task<GetDealPagesDto<Domain.Models.Deal>> GetAllDealsAsync(GetDealPagesRequestDto dto)
    {
        var deals = _db.Deals.Where(d => d.OwnerId == dto.Id);
        #region Пагинация

        int totalItems = deals.Count();
        int totalPages = 0;
        if (dto.Page > 0)
        {
            const int pageSize = 10;
            int skip = (dto.Page - 1) * pageSize;
            deals = deals.Skip(skip).Take(pageSize);
            totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
        #endregion

        var result = await deals.ToListAsync();

        return new GetDealPagesDto<Domain.Models.Deal>(result, totalPages);
    }
    
    public async Task<GetDealPagesDto<Domain.Models.Deal>> GetAllTenantDealsAsync(GetDealPagesRequestDto dto)
    {
        var deals = _db.Deals.Where(d => d.TenantId == dto.Id);
        #region Пагинация

        int totalItems = deals.Count();
        int totalPages = 0;
        if (dto.Page > 0)
        {
            const int pageSize = 10;
            int skip = (dto.Page - 1) * pageSize;
            deals = deals.Skip(skip).Take(pageSize);
            totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
        #endregion

        var result = await deals.ToListAsync();

        return new GetDealPagesDto<Domain.Models.Deal>(result, totalPages);
    }
}