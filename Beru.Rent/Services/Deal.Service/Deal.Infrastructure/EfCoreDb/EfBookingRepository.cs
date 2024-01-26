    using Deal.Api.DTO;
    using Deal.Application.Contracts.Booking;
    using Deal.Domain.Enums;
    using Deal.Domain.Models;
    using Deal.Infrastructure.Persistance;

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

        public async Task<bool> CreateBookingAsync(Booking booking)
        {
            try
            {
                List<Booking> bookings = _db.Bookings.ToList();
                
                if (booking.Dbeg < DateTime.UtcNow.AddMinutes(-1))
                    return false;
                
                foreach (var book in bookings)
                {
                    if (booking.AdId == book.AdId && book.BookingState == BookingState.Accept.ToString())
                    {
                        if (booking.Dbeg > book.Dbeg && booking.Dbeg < book.Dend || 
                            booking.Dend > book.Dbeg && booking.Dend < book.Dend ||
                            booking.Dbeg < book.Dbeg && booking.Dend > book.Dend 
                            )
                        {
                            return false;
                        }
                    }
                }

                HttpResponseMessage response = await _httpClient.GetAsync($"http://localhost:5105/api/ad/getCost/{booking.AdId}&{booking.Dbeg.ToString().Replace('/', '-')}&{booking.Dend.ToString().Replace('/', '-')}");
                if (response.IsSuccessStatusCode)
                {
                    booking.Cost = decimal.Parse(await response.Content.ReadAsStringAsync());
                    _db.Bookings.Add(booking);
                    await _db.SaveChangesAsync();
                    return true; 
                }
                else
                {
                    return false;
                }
                
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        

        public async Task<DateTime[,]> GetAllBookingsAsync(Guid id)
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
            List<Booking> bookings =_db.Bookings.ToList();
            List<BookingDto> theBooking = new List<BookingDto>();
            foreach (var books in bookings)
            {
                // if (id == books.TenantId)
                // {
                //     theBooking.Add(new BookingDto{
                //         AdId = books.AdId,
                //         TenantId = books.TenantId,
                //         Dbeg = books.Dbeg,
                //         Dend = books.Dend,
                //         Cost = books.Cost,
                //         BookingState = books.BookingState
                //         });
                // }   
            }
            return theBooking;
        }
    }