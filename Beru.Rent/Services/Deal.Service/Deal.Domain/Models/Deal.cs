using System.Runtime.InteropServices.JavaScript;
using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class Deal: DealEntity
{
     public Guid OwnerId { get; set; }
     public string DealState { get; set; }
     public decimal Deposit { get; set; }
     public string ChatId { get; set; }

     public Deal(
          Guid adId,
          Guid tenantId,
          decimal cost,
          Guid ownerId,
          string dealState,
          decimal deposit
     )
     {
         AdId = adId;
         TenantId = tenantId;
         Cost = cost;
         OwnerId = ownerId;
         DealState = dealState;
         Deposit = deposit;
         Dbeg = DateTime.UtcNow;
         CreatedAt = DateTime.UtcNow;
     }
     
     private Deal(){}
}