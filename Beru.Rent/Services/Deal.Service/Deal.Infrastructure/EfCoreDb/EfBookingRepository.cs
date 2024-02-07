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
            var books = await _db.Bookings.Where(b => b.AdId == id.Id).Where(b => b.BookingState == BookingState.Accept.ToString()).ToListAsync();
            return books; 
        }

        public async Task<GetDealPagesDto<Booking>> GetAllBookingsAsync(GetDealPagesRequestDto dto)
        {
            List<Booking> books = new List<Booking>();
            var bookings = _db.Bookings.Where(b => b.OwnerId == dto.Id);
            foreach (var book in bookings) 
                books.Add(book);

            #region Пагинация

            int totalItems = bookings.Count();
            int totalPages = 0;
            if (dto.Page > 0)
            {
                const int pageSize = 10;
                int skip = (dto.Page - 1) * pageSize;
                bookings = bookings.Skip(skip).Take(pageSize);
                totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            }
            #endregion

            var result = await bookings.ToListAsync();
            
            return new GetDealPagesDto<Booking>(result,totalPages);
        }

        public async Task<Booking> GetBookingAsync(RequestById dto)
        {
            return await _db.Bookings.FirstOrDefaultAsync(b => b.Id == dto.Id);
        }

        public async Task<GetDealPagesDto<Booking>> GetAllTenantBookingsAsync(GetDealPagesRequestDto dto)
        {
            List<Booking> books = new List<Booking>();
            var bookings = _db.Bookings.Where(b => b.TenantId == dto.Id);
            foreach (var book in bookings) 
                books.Add(book);   
            
            #region Пагинация

            int totalItems = bookings.Count();
            int totalPages = 0;
            if (dto.Page > 0)
            {
                const int pageSize = 10;
                int skip = (dto.Page - 1) * pageSize;
                bookings = bookings.Skip(skip).Take(pageSize);
                totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            }
            #endregion

            var result = await bookings.ToListAsync();
            
            return new GetDealPagesDto<Booking>(result,totalPages);
        }
    }