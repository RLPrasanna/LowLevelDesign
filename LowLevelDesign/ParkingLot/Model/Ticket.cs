using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Model
{
    internal class Ticket : BaseModel
    {
        public string Number { get; set; }
        public DateTime EntryTime { get; set; }
        public Vehicle Vehicle { get; set; }
        public ParkingSpot AssignedSpot { get; set; }
        public ParkingLotGate GeneratedAt { get; set; }
        public Operator GeneratedBy { get; set; } // Optional to keep GeneratedBy here

        public Ticket(string number, DateTime entryTime, Vehicle vehicle, ParkingSpot parkingSpot, ParkingLotGate generatedAt, Operator generatedBy)
        {
            this.Number = number;
            this.EntryTime = entryTime;
            this.Vehicle = vehicle;
            this.AssignedSpot = parkingSpot;
            this.GeneratedAt = generatedAt;
            this.GeneratedBy = generatedBy;
        }
    }
}
