using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class ParkingFloorDTO
    {
        public List<ParkingSpot> ParkingSpot { get; set; }
        public string FloorNumber { get; set; }

        public ParkingFloorDTO(List<ParkingSpot> parkingSpot, string floorNumber)
        {
            this.ParkingSpot = parkingSpot;
            this.FloorNumber = floorNumber;
        }
    }
}
