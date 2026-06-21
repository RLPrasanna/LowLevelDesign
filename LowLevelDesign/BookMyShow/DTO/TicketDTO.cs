using BookMyShow.Model;

namespace BookMyShow.DTO
{
    public class TicketDTO
    {
        public long TicketId { get; set; }
        public User CreatedBy { get; set; }
        public double TotalAmount { get; set; }
    }
}
