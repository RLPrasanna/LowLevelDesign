namespace Splitwise.Models
{
    public class GroupExpense : BaseModel
    {
        public long GroupId { get; set; }
        public long ExpenseId { get; set; }
    }
}
