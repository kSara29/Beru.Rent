using Common;
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
                
                if (dto.Dbeg < DateTime.UtcNow.AddMinutes(-1)) //Написать в сервисе + добавить ошибку и вернуть fail
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

                    Booking booking = dto.ToDomain();
                    _db.Bookings.Add(booking);
                    await _db.SaveChangesAsync();
                    return true;
        }
        

        public async Task<List<GetBookingDatesResponse>> GetBookingDatesAsync(RequestById id)
        {
            var books = _db.Bookings.ToList().Where(b => b.AdId == id.Id).ToList();
            List<GetBookingDatesResponse> list = new List<GetBookingDatesResponse>();
            foreach (var book in books) 
                list.Add(book.ToDto());
            return list; 
            
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