using System.Runtime.InteropServices.JavaScript;
using Deal.Domain.Common;
using Deal.Domain.Enums;
namespace Deal.Domain.Models;

public class Deal: DealEntity
{
     public string OwnerId { get; set; }
     public DealState DealState{ get; set; }
     public decimal Deposit { get; set; }
     public string ChatId { get; set; }

     public Deal(
          Guid adId,
          Guid tenantId,
          decimal? cost,
          string ownerId,
          DateTime dbeg,
          DateTime dend
     )
     {
         AdId = adId;
         TenantId = tenantId;
         Cost = cost;
         OwnerId = ownerId;
         DealState = DealState.Open;
         CreatedAt = DateTime.UtcNow;
         Dbeg = dbeg;
         Dend = dend;
     }
     
     private Deal(){}
}