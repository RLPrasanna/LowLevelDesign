namespace Splitwise.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}