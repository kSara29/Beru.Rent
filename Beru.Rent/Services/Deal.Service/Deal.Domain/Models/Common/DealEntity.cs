namespace Deal.Domain.Common;

public class DealEntity: BaseEntity
{
    public Guid AdId { get; set; }
    public Guid TenantId { get; set; }
    public DateTime Dbeg { get; set; }
    public DateTime Dend { get; set; }
    public DateTime? CancelAt { get; set; }
    public decimal? Cost { get; set; }
}