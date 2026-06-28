using Splitwise.Models;
using System.Runtime.InteropServices;

namespace Splitwise.Repository
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        private Dictionary<long, Expense> expenseRepo;
        private static long lastId = 1;
        public ExpenseRepository(AppDBContext context) : base(context)
        {
        }

        public override Expense Add(Expense entity)
        {
            entity.Id = lastId++;
            expenseRepo[entity.Id] = entity;
            return entity;
        }

        public override Expense GetById(long id)
        {
            return expenseRepo.TryGetValue(id, out var entity) ? entity : null;
        }
    }
}
