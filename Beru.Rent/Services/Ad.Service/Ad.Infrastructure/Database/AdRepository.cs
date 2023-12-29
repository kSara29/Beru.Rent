

using Ad.Application.Contracts.Ad;
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
   public async Task<bool> ArchiveAsync(Advertisement ad)
   {
      throw new NotImplementedException();
   }

   public async Task<bool> ActivateAsync(Advertisement ad)
   {
      throw new NotImplementedException();
   }

   public async Task<Guid> CreateAdAsync(Advertisement ad)
   {
      throw new NotImplementedException();
   }

   public async Task<Advertisement> GetAdAsync(Guid id)
   {
      throw new NotImplementedException();
   }
}