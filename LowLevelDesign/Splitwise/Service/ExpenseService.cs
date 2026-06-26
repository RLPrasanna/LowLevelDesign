using Splitwise.Models;
using Splitwise.Repository;

namespace Splitwise.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository expenseRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserExpenseRepository userExpenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
            expenseRepository = expenseRepository;
            userRepository = userRepository;
            userExpenseRepository = userExpenseRepository;
        }
        public Expense CreateExpense(string description, double amount, long createdByUserId, List<long> userExpenseIds)
        {

            throw new NotImplementedException();
        }
    }
}
