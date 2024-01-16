

using Ad.Application.Contracts.Ad;
using Ad.Domain.Models;
using Ad.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Ad.Infrastructure;

public class AdRepository : IAdRepository
{
   private readonly AdContext _context;

   public AdRepository(AdContext context)
   {
      _context = context;
   }

   public async Task<bool> ArchiveAsync(Guid id)
   {
      var ad = await _context.Ads.FindAsync(id);
      ad.State = AdState.Archive;
      return true;
   }

   public async Task<bool> ActivateAsync(Guid id)
   {
      var ad = await _context.Ads.FindAsync(id);
      ad.State = AdState.Active;
      return true;   
   }

   public async Task<Guid> CreateAdAsync(Advertisement ad)
   { 
      await _context.Ads.AddAsync(ad); 
      await _context.SaveChangesAsync(); 
      return ad.Id;
   }

   public async Task<Advertisement?> GetAdAsync(Guid id)
   {
      var ad = await _context.Ads.FindAsync(id);
      return ad;

   }

   public  async Task<List<Advertisement>?> GetAllAdAsync()
   {
      var result = _context.Ads
         .Include(a=>a.Category)
         .Include(a=>a.AddressExtra)
         .ToList();
      return result;
   }
}