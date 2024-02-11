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

    public async Task<ResponseModel<CreateDealResponseDto>> CreateDealAsync(CreateDealRequestDto dto)
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
                await _db.Deals.AddAsync(deal);
                await _db.SaveChangesAsync();
                //Dictionary<bool, Guid> trueres = new Dictionary<bool, Guid>() {[true] = deal.Id };
                var participiants = new List<string>();
                participiants.Add(book.OwnerId);
                participiants.Add(book.TenantId);
                var dealDto = new CreateDealResponseDto(deal.Id, true, participiants);
                return ResponseModel<CreateDealResponseDto>.CreateSuccess(dealDto);
            }
            else
            {
                book.BookingState = BookingState.Decline.ToString();
                await _db.SaveChangesAsync();
                Domain.Models.Deal deal = new Domain.Models.Deal();
                //Dictionary<bool, Guid> falseres = new Dictionary<bool, Guid>() {[false] = deal.Id };
                //return falseres;
                var dealDto = new CreateDealResponseDto(deal.Id, false, new List<string>());
                return ResponseModel<CreateDealResponseDto>.CreateSuccess(dealDto);
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