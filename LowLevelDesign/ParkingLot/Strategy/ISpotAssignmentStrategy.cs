using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Strategy
{
    internal interface ISpotAssignmentStrategy
    {
        public ParkingSpot FindParkingSpot(ParkingLot parkingLot, VehicleType vehicleType);
    }
}
