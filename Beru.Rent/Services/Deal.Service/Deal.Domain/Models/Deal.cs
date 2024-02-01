using System.Runtime.InteropServices.JavaScript;
using Deal.Domain.Common;
using Deal.Domain.Enums;
namespace Deal.Domain.Models;

public class Deal: DealEntity
{
     public DealState DealState{ get; set; }
     public decimal Deposit { get; set; }
     public Guid ChatId { get; set; }

     public Deal(
          Guid adId,
          string tenantId,
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

     public Deal()
     {
         CreatedAt = DateTime.UtcNow;
     }

}