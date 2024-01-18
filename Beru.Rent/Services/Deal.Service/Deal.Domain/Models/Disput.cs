using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class Disput : BaseEntity
{
    public DateTime? ClosedAt { get; set; }
    public required string DealId { get; set; }

    public Disput(string dealId)
    {
        DealId = dealId;
    }

    public Disput(DateTime? closedAt, string dealId)
    {
        ClosedAt = closedAt;
        DealId = dealId;
    }
}