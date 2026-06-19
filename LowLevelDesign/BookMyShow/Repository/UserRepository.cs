using BookMyShow.Data;
using BookMyShow.Model;

namespace BookMyShow.Repository
{
    public class UserRepository : Repository<User>, IUserReository
    {

        private AppDBContext _db;
        public UserRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
