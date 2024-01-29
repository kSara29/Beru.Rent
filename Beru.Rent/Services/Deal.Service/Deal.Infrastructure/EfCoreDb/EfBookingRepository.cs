using Deal.Application.Contracts.Booking;
using Deal.Application.Mapper;
using Deal.Domain.Enums;
    using Deal.Domain.Models;
    using Deal.Dto.Booking;
    using Deal.Infrastructure.Persistance;
    using Microsoft.EntityFrameworkCore;

    namespace Deal.Infrastructure.EfCoreDb;

    public class EfBookingRepository: IBookingRepository
    {
        private readonly DealContext _db;
        private readonly HttpClient _httpClient;

        public EfBookingRepository(DealContext db, HttpClient httpClient)
        {
            _db = db;
            _httpClient = httpClient;
        }

        public async Task<bool> CancelReservationAsync(Booking booking)
        {
            try
            {
                booking.BookingState = BookingState.Decline.ToString();
                booking.CancelAt = DateTime.UtcNow;
                _db.Bookings.Update(booking);
                await _db.SaveChangesAsync();
                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateBookingAsync(CreateBookingRequestDto dto)
        {
               var bookings = _db.Bookings.ToList();
                
                if (dto.Dbeg < DateTime.UtcNow.AddMinutes(-1))
                    return false;
                
                foreach (var book in bookings)
                {
                    if (book.AdId == dto.AdId && book.BookingState == BookingState.Accept.ToString())
                    {
                        if (dto.Dbeg > book.Dbeg && dto.Dbeg < book.Dend || 
                            dto.Dend > book.Dbeg && dto.Dend < book.Dend ||
                            dto.Dbeg < book.Dbeg && dto.Dend > book.Dend 
                            )
                        {
                            return false;
                        }
                    }
                }

                // HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:5105/api/ad/getCost/{booking.AdId}&{booking.Dbeg.ToString().Replace('/', '-')}&{booking.Dend.ToString().Replace('/', '-')}");
                // if (response.IsSuccessStatusCode)
                // {
                //     booking.Cost = decimal.Parse(await response.Content.ReadAsStringAsync());
                    Booking booking = dto.ToDomain();
                    _db.Bookings.Add(booking);
                    await _db.SaveChangesAsync();
                    return true; 
                // }
                // else
                // {
                //     return false;
                // }  После того, как поключат Ad service к Bff и можно будет взять данные по вычету Cost
                
            
        }
        

        public async Task<DateTime[,]> GetBookingDatesAsync(Guid id)
        {
            List<Booking> bookings = _db.Bookings.ToList();
            int size = 0;
            List<Booking> newbookings = new List<Booking>();
            foreach (var book in bookings)
            {
                if (book.AdId == id)
                {
                    size++;
                    newbookings.Add(book);
                }
            }
            
            DateTime[,] result = new DateTime[size,2];

            for (int i = 0; i < newbookings.Count; i++)
            {
                result[i, 0] = newbookings[i].Dbeg;
                result[i, 1] = newbookings[i].Dend;
            }
                return result; 
            
        }

        public async Task<List<BookingDto>> GetBookingsAsync(Guid id)
        {
            List<Booking> bookings =await _db.Bookings.Where(b => b.TenantId == id).ToListAsync();
            List<BookingDto> theBooking = new();
            foreach (var books in bookings)
                theBooking.Add(books.ToDomain());
            return theBooking;
        }
    }