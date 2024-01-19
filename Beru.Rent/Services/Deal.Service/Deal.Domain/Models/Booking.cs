using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class Booking: DealEntity
{ 
    public string BookingState { get; set; }

    
    
    public Booking(
        Guid adId,
        Guid tenantId,
        decimal cost,
        DateTime dbeg,
        DateTime dend)
    {
        AdId = adId;
        TenantId = tenantId;
        Cost = cost;
        Dbeg = dbeg;
        Dend = dend;
        BookingState = Enums.BookingState.InQueue.ToString();
        CreatedAt = DateTime.UtcNow;
    }

    public Booking( Guid adId)
    {
        AdId = adId;
    }

    public Booking()
    {
    }
}