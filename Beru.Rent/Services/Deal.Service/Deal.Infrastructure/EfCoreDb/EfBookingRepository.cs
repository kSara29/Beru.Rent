    using Deal.Application.Contracts.Booking;
    using Deal.Domain.Enums;
    using Deal.Domain.Models;
    using Deal.Infrastructure.Persistance;

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

        public async Task<bool> CreateBookingAsync(Booking booking)
        {
            try
            {
                _db.Bookings.Add(booking);
                await _db.SaveChangesAsync();
                return true; 
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