using BookMyShow.Data;
using BookMyShow.Model;
using System.Linq.Expressions;

namespace BookMyShow.Repository
{
    public class ShowRepository : Repository<Show>, IShowRepository
    {
        private AppDBContext _db;
        public ShowRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
