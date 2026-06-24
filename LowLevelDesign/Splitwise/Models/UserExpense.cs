using Splitwise.Models.Enum;

namespace Splitwise.Models
{
    public class UserExpense  :BaseModel
    {
        public Expense Expense { get; set; }
        public User User { get; set; }
        public double Amount { get; set; }
        public UserExpenseType UserExpenseType { get; set; }
    }
}
