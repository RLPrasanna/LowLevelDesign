using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Service
{
    internal interface ITicketService
    {
        public string GenerateTicket(long gateId, long parkingLotId, Model.Vehicle vehicle);
    }
}
