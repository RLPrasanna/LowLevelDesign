using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class GenerateTicketDTO
    {
        public long GateId { get; set; }
        public long ParkingLotId { get; set; }
        public Vehicle Vehicle { get; set; }

        public GenerateTicketDTO(long gateId, long parkingLotId, Vehicle vehicle)
        {
            this.GateId = gateId;
            this.ParkingLotId = parkingLotId;
            this.Vehicle = vehicle;
        }
    }
}
