using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class ContractStorage: BaseEntity
{
    public string DealId { get; set; }
    public string TemplatePath { get; set; }
    public string SignedByTenanPath { get; set; }
    public string SignedByOwnerPath { get; set; }
}