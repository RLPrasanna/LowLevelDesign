using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class BillRequestDTO
    {
        public string TicketNumber { get; set; }
        public int GateId { get; set; }
    }
}
