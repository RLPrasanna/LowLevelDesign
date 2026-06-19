namespace BookMyShow.DTO
{
    public class CreateBookingRequestDTO
    {
        public long ShowId { get; set; }
        public List<string> SeatNumbers { get; set; }
        public long UserId { get; set; }
    }
}
