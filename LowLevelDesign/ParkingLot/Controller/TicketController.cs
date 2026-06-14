using ParkingLotManagement.DTO;
using ParkingLotManagement.Service;

namespace ParkingLotManagement.Controller
{
    internal class TicketController
    {
        private TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public TicketResponseDTO GenerateTicket(GenerateTicketDTO generateTicketDTO)
        {
            // Logic to generate a ticket based on the provided DTO
            // This would typically involve validating the input, checking for available parking spots, and creating a new Ticket instance.
            
            if (!ValidateGenerateTicketDTO(generateTicketDTO)){
                throw new ArgumentException("Invalid input for generating ticket.");
            }

            try
            {
                string ticketNumber = this._ticketService.GenerateTicket(generateTicketDTO.GateId, generateTicketDTO.ParkingLotId, generateTicketDTO.Vehicle);

                return new TicketResponseDTO
                {
                    ResponseStatus = Model.Enums.ResponseStatus.SUCCESS,
                    Number = ticketNumber
                };
            }
            catch (Exception ex)
            {
                return new TicketResponseDTO
                {
                    ResponseStatus = Model.Enums.ResponseStatus.FAILURE,
                    FailureMessage = ex.Message
                };
            }
        }


        private bool ValidateGenerateTicketDTO(GenerateTicketDTO dto)
        {
            if (dto == null || dto.GateId <= 0 || dto.ParkingLotId <= 0 || dto.Vehicle == null)
            {
                return false;
            }
            // Additional validation logic can be added here as needed.
            return true;
        }
    }
}
