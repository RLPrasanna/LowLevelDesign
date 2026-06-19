using BookMyShow.Data;
using BookMyShow.Model;

namespace BookMyShow.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private AppDBContext _db;
        public BookingRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
