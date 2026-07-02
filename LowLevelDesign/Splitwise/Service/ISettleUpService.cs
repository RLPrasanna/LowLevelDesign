using Splitwise.Models;

namespace Splitwise.Service
{
    public interface ISettleUpService
    {
        List<Expense> SettleUpUser(long userId);
    }
}
