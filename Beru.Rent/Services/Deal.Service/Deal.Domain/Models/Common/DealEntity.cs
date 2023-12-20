namespace Deal.Domain.Common;

public class DealEntity: BaseEntity
{
    public string AdId { get; set; }
    public string TenantId { get; set; }
    public DateTime Dbeg { get; set; }
    public DateTime Dend { get; set; }
    public decimal Cost { get; set; }
}