using System.Runtime.InteropServices.JavaScript;
using Deal.Domain.Common;
using Deal.Domain.Enums;
namespace Deal.Domain.Models;

public class Deal: DealEntity
{
     public string DealState{ get; set; }
     public decimal Deposit { get; set; }
     public Guid ChatId { get; set; }
     public Guid BookingId { get; set; }

     public Deal(
          Guid adId,
          string tenantId,
          decimal? cost,
          string ownerId,
          DateTime dbeg,
          DateTime dend,
          Guid bookingId
     )
     {
         AdId = adId;
         TenantId = tenantId;
         Cost = cost;
         OwnerId = ownerId;
         CreatedAt = DateTime.UtcNow;
         Dbeg = dbeg;
         Dend = dend;
         BookingId = bookingId;
     }

     public Deal()
     {
         CreatedAt = DateTime.UtcNow;
     }

}