namespace Splitwise.Models
{
    public class Group : BaseModel
    {
        public string Name { get; set; }
        public List<User> Members { get; set; }
        public List<Expense> Expenses { get; set; }
        public User GroupCreatedBy { get; set; }
    }
}
