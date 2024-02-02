using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class Booking: DealEntity
{ 
    public string BookingState { get; set; }

    
    
    public Booking(
        Guid adId,
        string tenantId,
        decimal? cost,
        DateTime dbeg,
        DateTime dend,
        string ownerId)
    {
        AdId = adId;
        TenantId = tenantId;
        Cost = cost;
        Dbeg = dbeg;
        Dend = dend;
        BookingState = Enums.BookingState.InQueue.ToString();
        CreatedAt = DateTime.UtcNow;
        OwnerId = ownerId;
    }
    
    public Booking(
        Guid adId,
        string tenantId,
        DateTime dbeg,
        DateTime dend)
    {
        AdId = adId;
        TenantId = tenantId;
        Dbeg = dbeg;
        Dend = dend;
        BookingState = Enums.BookingState.InQueue.ToString();
        CreatedAt = DateTime.UtcNow;
    }

    public Booking()
    {
        BookingState = Enums.BookingState.Decline.ToString();
        CreatedAt = DateTime.UtcNow;
    }
}