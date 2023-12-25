using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class Booking: DealEntity
{ 
    public string BookingState { get; set; }

    public Booking(
        string adId,
        string tenantId,
        decimal cost)
    {
        AdId = adId;
        TenantId = tenantId;
        Cost = cost;
        BookingState = Enums.BookingState.InQueue.ToString();
        CreatedAt = DateTime.UtcNow;
        Dbeg = DateTime.UtcNow;
    }

    public Booking()
    {
    }
}