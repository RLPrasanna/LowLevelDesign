using Splitwise.Models.Enum;

namespace Splitwise.Models
{
    public class Expense : BaseModel
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public List<UserExpense> UserExpenses { get; set; }
    }
}
