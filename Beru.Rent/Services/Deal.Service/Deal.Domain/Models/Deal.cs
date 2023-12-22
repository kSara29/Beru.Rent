using System.Runtime.InteropServices.JavaScript;
using Deal.Domain.Common;

namespace Deal.Domain.Models;

public class Deal: DealEntity
{
     public string OwnerId { get; set; }
     public string DealState { get; set; }
     public decimal Deposit { get; set; }
     public string ChatId { get; set; }

     public Deal(
          string adId,
          string tenantId,
          decimal cost,
          string ownerId,
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