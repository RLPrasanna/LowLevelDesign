using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Model
{
    internal class ParkingFloor : BaseModel
    {
        public List<ParkingSpot> ParkingSpot { get; set; }
        public string FloorNumber { get; set; }

        public ParkingFloor(List<ParkingSpot> parkingSpot, string floorNumber)
        {
            this.ParkingSpot = parkingSpot;
            this.FloorNumber = floorNumber;
        }
    }
}
