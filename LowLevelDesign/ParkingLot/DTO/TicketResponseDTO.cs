using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class TicketResponseDTO
    {
        public string Number { get; set; }

        public TicketResponseDTO(string number)
        {
            this.Number = number;
        }
    }
}
