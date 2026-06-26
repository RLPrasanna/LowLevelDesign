using Splitwise.Models;

namespace Splitwise.Service
{
    public interface IExpenseService
    {
        Expense CreateExpense(string description, double amount, long createdByUserId, List<long> userExpenseIds);
    }
}
