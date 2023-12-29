

using Ad.Domain.Models;

namespace Ad.Infrastructure;

public class AdRepository : IAdRepository
{
   // Task<bool> ArchiveAsync(Domain.Core.Models.Ad ad)
   //  {
   //      ad.State = AdState.Archive;
   //      return ad;
   //  }
   //
   // Task<> ActivateAsync(Domain.Core.Models.Ad ad)
   //  {
   //      ad.State = AdState.Active;
   //      return ad;
   //  }
   public Task<bool> ArchiveAsync(Advertisement ad)
   {
      throw new NotImplementedException();
   }

   public Task<bool> ActivateAsync(Advertisement ad)
   {
      throw new NotImplementedException();
   }

   public Task<Guid> CreateAdAsync(Advertisement ad)
   {
      throw new NotImplementedException();
   }
}