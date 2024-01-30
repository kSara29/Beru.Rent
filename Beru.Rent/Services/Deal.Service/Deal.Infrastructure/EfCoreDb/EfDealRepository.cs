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

    public async Task<Guid> CreateDealAsync(CreateDealRequestDto dto)
    {
            Booking? book = await _db.Bookings.FirstOrDefaultAsync(b => b.Id == dto.bookingId);
            Domain.Models.Deal deal = new Domain.Models.Deal(
                book.AdId,
                book.TenantId,
                book.Cost,
                dto.ownerId,
                book.Dbeg,
                book.Dend
            );
            if (dto.isApproved)
                deal.DealState = DealState.Open;
            else
                deal.DealState = DealState.Close;
            return deal.Id;
    }
}