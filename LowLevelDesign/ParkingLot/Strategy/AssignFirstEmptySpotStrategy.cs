using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Strategy
{
    internal class AssignFirstEmptySpotStrategy : ISpotAssignmentStrategy
    {
        public ParkingSpot FindParkingSpot(ParkingLot parkingLot, VehicleType vehicleType)
        {
            Console.WriteLine("Assigning first empty spot strategy");
            foreach(var floor in parkingLot.ParkingFloors)
            {
                foreach (var spot in floor.ParkingSpot)
                {
                    if (spot.SupportedVehicleTypes.Contains(vehicleType) && spot.ParkingSpotStatus == ParkingSpotStatus.Empty)
                    {
                        Console.WriteLine($"Found empty spot: {spot.SpotNumber} for vehicle type: {vehicleType}");
                        return spot;
                    }
                }
            }
            return null;
        }
    }
}
