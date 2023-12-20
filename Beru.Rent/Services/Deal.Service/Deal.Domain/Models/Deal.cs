using Deal.Domain.Common;
using Deal.Domain.Enums;

namespace Deal.Domain.Models;

public class Deal: DealEntity
{
     public string OwnerId { get; set; }
     public string DealState { get; set; }
     public decimal Deposit { get; set; }
     public string ChatId { get; set; }
}