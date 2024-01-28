using Deal.Application.Contracts.Deal;
using Deal.Domain.Models;
using Deal.Dto.Deal;
using Deal.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Deal.Infrastructure.EfCoreDb;

public class EfDealRepository: IDealRepository
{
    private readonly DealContext _db;
    private readonly HttpClient _httpClient;

    public EfDealRepository(DealContext db, HttpClient httpClient)
    {
        _db = db;
        _httpClient = httpClient;
    }

    public async Task<CreateDealDto> CreateDealAsync(Guid id)
    {
        try
        {
            Booking? book = await _db.Bookings.FirstOrDefaultAsync(b => b.Id == id);

            HttpResponseMessage response =
                await _httpClient.GetAsync($"http://localhost:5105/api/ad/getOwnerId/{book.AdId}");

            if (response.IsSuccessStatusCode)
            {
                string ownerId = await response.Content.ReadAsStringAsync();
                CreateDealDto dto =new CreateDealDto(
                    book.AdId,
                    book.TenantId,
                    book.Cost,
                    ownerId,
                    book.Dbeg,
                    book.Dend
                );
                return dto;   
            }
            else
            {
                return null;
            }
            
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}