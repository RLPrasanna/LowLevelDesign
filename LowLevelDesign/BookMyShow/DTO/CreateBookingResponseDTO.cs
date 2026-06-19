using BookMyShow.Model.Enums;

namespace BookMyShow.DTO
{
    public class CreateBookingResponseDTO
    {
        public long TicketId { get; set; }
        public List<string> BookedSeatNumbers { get; set; }
        public BookingStatus BookingStatus { get; set; }
    }
}
