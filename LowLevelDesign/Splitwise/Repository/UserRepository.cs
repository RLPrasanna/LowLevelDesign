using Splitwise.Models;

namespace Splitwise.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDBContext context) : base(context)
        {
        }
    }
}
