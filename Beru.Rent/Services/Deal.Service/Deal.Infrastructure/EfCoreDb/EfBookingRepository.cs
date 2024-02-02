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

        public EfBookingRepository(DealContext db)
        {
            _db = db;
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

        public async Task<Dictionary<bool,Booking>> CreateBookingAsync(CreateBookingRequestDto dto)
        {
                
               var bookings = _db.Bookings.ToList();
               Booking falseBooking = new Booking();

               if (dto.Dbeg < DateTime.UtcNow.AddMinutes(-1)) //Написать в сервисе + добавить ошибку и вернуть fail
               {
                   Dictionary<bool, Booking> falseresult = new Dictionary<bool, Booking>()
                   { 
                       [false]=falseBooking
                   };
                   return falseresult;
               }
                
                foreach (var book in bookings)
                {
                    if (book.AdId == dto.AdId && book.BookingState == BookingState.Accept.ToString())
                    {
                        if (dto.Dbeg > book.Dbeg && dto.Dbeg < book.Dend || 
                            dto.Dend > book.Dbeg && dto.Dend < book.Dend ||
                            dto.Dbeg < book.Dbeg && dto.Dend > book.Dend 
                            )
                        {
                            Dictionary<bool, Booking> falseresult = new Dictionary<bool, Booking>()
                            { 
                                [false]=falseBooking
                            };
                            return falseresult;
                        }
                    }
                }

                    Booking booking = dto.ToDomain();
                    _db.Bookings.Add(booking);
                    await _db.SaveChangesAsync();
                    Dictionary<bool, Booking> result = new Dictionary<bool, Booking>()
                    { 
                        [true]=booking
                    };
                    return result;
        }
        

        public async Task<List<Booking>> GetBookingDatesAsync(RequestById id)
        {
            var books = await _db.Bookings.Where(b => b.AdId == id.Id).ToListAsync();
            return books; 
        }

        public async Task<List<Booking>> GetAllBookingsAsync(RequestByUserId id)
        {
            List<Booking> books = new List<Booking>();
            List<Booking> bookings = await _db.Bookings.Where(b => b.OwnerId == id.Id).ToListAsync();
            foreach (var book in bookings) 
                books.Add(book);   
            
            return books;
        }

        public async Task<Booking> GetBookingAsync(RequestById id)
        {
            return await _db.Bookings.FirstOrDefaultAsync(b => b.Id == id.Id);
        }

        public async Task<List<Booking>> GetAllTenantBookingsAsync(RequestByUserId id)
        {
            List<Booking> books = new List<Booking>();
            List<Booking> bookings = await _db.Bookings.Where(b => b.TenantId == id.Id).ToListAsync();
            foreach (var book in bookings) 
                books.Add(book);   
            
            return books;
        }
    }