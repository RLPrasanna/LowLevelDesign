using BookMyShow.DTO;
using BookMyShow.Exceptions;
using BookMyShow.Model;
using BookMyShow.Service;
using BookMyShow.Translator;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private BookingService bookingService;

        [HttpPost("ticket")]
        public CreateBookingResponseDTO BookTicket([FromBody] CreateBookingRequestDTO requestDTO)
        {
            if (IsInvalidRequest(requestDTO)){
                throw new InvalidRequestException("Invalid Request");
            }

            Booking booking=bookingService.CreateBooking(requestDTO.SeatNumbers, requestDTO.ShowId, requestDTO.UserId);
            Console.WriteLine("created booking successfully with id: " + booking.Id);
            return BookingTranslator.transform(booking, requestDTO);
        }




        #region private methods
        private bool IsInvalidRequest(CreateBookingRequestDTO request)
        {
            // Todo:
            return false;
        }
        #endregion
    }
}
