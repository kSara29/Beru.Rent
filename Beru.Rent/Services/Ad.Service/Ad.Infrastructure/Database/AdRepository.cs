

using Ad.Application.Contracts.Ad;
using Ad.Application.Mapper;
using Ad.Application.DTO.GetDtos;
using Ad.Domain.Models;
using Ad.Infrastructure.Context;
using Deal.Dto.Booking;
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
      var ad = await _context.Ads
         .Include(a => a.Category)
         .Include(a => a.AddressExtra)
         .Include(a => a.TimeUnit)
         .Include(a=>a.Files)
         .FirstOrDefaultAsync(a=>a.Id==id);
      return ad;

   }

   public async Task<List<Advertisement>?> GetAdsByUserId(Guid userId)
   {
      var result =  await _context.Ads
         .Include(a => a.Category)
         .Include(a => a.AddressExtra)
         .Include(a => a.TimeUnit)
         .Include(a=>a.Files)
         .Where(a=>a.UserId == userId.ToString()).ToListAsync();

      return result;

   }

   public  async Task<GetMainPageDto<Advertisement>?> GetAllAdAsync(int page, string sortdate, string sortprice, string cat)
   {
      IQueryable<Advertisement> query = _context.Ads
         .Include(a => a.Category)
         .Include(a => a.AddressExtra)
         .Include(a => a.TimeUnit)
         .Include(a=>a.Files);

      #region Сортировка по категории
      if (cat != "all")
      {
         query = query.Where(a => a.Category.Title == cat);
      }
      #endregion

      #region Сортировка по дате
      switch (sortdate.ToLower())
      {
         case "fromnew":
            query = query.OrderByDescending(a => a.CreatedAt);
            break;
         case "fromold":
            query = query.OrderBy(a => a.CreatedAt);
            break;
      }
      #endregion
      
      #region Сортировка по цене
      switch (sortprice.ToLower())
      {
         case "fromhigh":
            query = query.OrderByDescending(a => a.Price); 
            break;
         case "fromlow":
            query = query.OrderBy(a => a.Price);
            break;
      }
      #endregion

      #region Пагинация
      int totalItems = await query.CountAsync();
      int totalPages = 0;
      if (page > 0)
      {
         const int pageSize = 9;
         int skip = (page - 1) * pageSize;
         query = query.Skip(skip).Take(pageSize);
         totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
      }
      
      #endregion
      
      
      var result = await query.ToListAsync();


      return new GetMainPageDto<Advertisement>(result, totalPages);
   }

   public async Task<decimal> GetCostAsync(CreateBookingRequestDto dto)
   {
      List<Advertisement> advertisements = _context.Ads.Include(a => a.TimeUnit).ToList();
      Advertisement TheAd = new Advertisement();
      foreach (var ads in advertisements)
      {
         if (ads.Id == dto.AdId)
         {
            TheAd = ads;
         }
      }
      
      decimal cost = Convert.ToDecimal((dto.Dend - dto.Dbeg) / TheAd.TimeUnit.Duration)*TheAd.Price;
      return cost;
   }


}