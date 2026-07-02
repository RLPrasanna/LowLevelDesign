using Splitwise.Models;
using Splitwise.Repository;

namespace Splitwise.Service
{
    public class SettleUpService : ISettleUpService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserExpenseRepository userExpenseRepository;

        public SettleUpService(UserRepository userRepository, UserExpenseRepository userExpenseRepository)
        {
            this.userRepository = userRepository;
            this.userExpenseRepository = userExpenseRepository;
        }

        public List<Expense> SettleUpUser(long userId)
        {
            /*
            1. Get the user with the given userId
            2. Get all the expenses in which this user is involved
            3. Iterate through all the expenses and find out who has paid
            extra/lesser for every user involved in the above list of expenses
            4. Use the Min/Max Heap algorithm to find out the list of transactions required to settle up the user
             */

            throw new NotImplementedException();
        }
    }
}
