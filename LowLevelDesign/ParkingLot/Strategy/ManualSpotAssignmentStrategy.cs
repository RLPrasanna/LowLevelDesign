using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Strategy
{
    internal class ManualSpotAssignmentStrategy : ISpotAssignmentStrategy
    {
        public ParkingSpot FindParkingSpot(ParkingLot parkingLot, VehicleType vehicleType)
        {
            return null; // Manual assignment strategy does not automatically find a spot
        }
    }
}
