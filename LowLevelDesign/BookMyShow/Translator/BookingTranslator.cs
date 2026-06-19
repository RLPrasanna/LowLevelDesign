using BookMyShow.DTO;
using BookMyShow.Model;

namespace BookMyShow.Translator
{
    public class BookingTranslator
    {
        public static CreateBookingResponseDTO transform(Booking booking, CreateBookingRequestDTO requestDTO)
        {
            CreateBookingResponseDTO responseDTO = new CreateBookingResponseDTO
            {
                BookingStatus = booking.BookingStatus,
                BookedSeatNumbers = requestDTO.SeatNumbers,
                TicketId = booking.Id
            };
            return responseDTO;
        }
    }
}
