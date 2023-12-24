using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class Booking: DealEntity
{ 
    public string BookingState { get; set; }

    public Booking(
        string adId,
        string tenantId,
        DateTime dbeg,
        DateTime dend,
        decimal cost,
        string bookingState)
    {
        AdId = adId;
        TenantId = tenantId;
        Dbeg = dbeg;
        Dend = dend;
        Cost = cost;
        BookingState = bookingState;
        CreatedAt = DateTime.UtcNow;
    }
    
    private Booking(){}
}