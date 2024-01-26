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

                HttpResponseMessage response = await _httpClient.GetAsync($"/api/ad/getAdds/{booking.AdId}/{booking.Dbeg}/{booking.Dend}");
                if (response.IsSuccessStatusCode)
                {
                    booking.Cost = decimal.Parse(response.ToString());
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
    }