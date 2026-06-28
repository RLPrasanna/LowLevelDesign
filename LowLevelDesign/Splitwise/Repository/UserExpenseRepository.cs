using Splitwise.Models;
using System.Runtime.InteropServices;

namespace Splitwise.Repository
{
    public class UserExpenseRepository : Repository<UserExpense>, IUserExpenseRepository
    {
        private AppDBContext _db;
        private Dictionary<long, UserExpense> userExpenseRepo;
        private static long lastId = 1;
        public UserExpenseRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public override IEnumerable<UserExpense> GetAll()
        {
            // Return all values stored in the dictionary
            return userExpenseRepo.Values.ToList();
        }

        public override UserExpense Add(UserExpense entity)
        {
            entity.Id = lastId++;
            userExpenseRepo[entity.Id] = entity;
            return entity;
        }

        public override UserExpense GetById(long id)
        {
            return userExpenseRepo.TryGetValue(id, out var entity) ? entity : null;
        }
    }
}
