using BookMyShow.DTO;
using BookMyShow.Exceptions;
using BookMyShow.Model;
using BookMyShow.Service;
using BookMyShow.Translator;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

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

        [HttpGet("ticket/{id}")]
        public ActionResult<TicketDTO> GetTicket(long id)
        {
            var ticket = new TicketDTO
            {
                CreatedBy=null,
                TicketId=id,
                TotalAmount=1000
            };
            return Ok(ticket);
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
