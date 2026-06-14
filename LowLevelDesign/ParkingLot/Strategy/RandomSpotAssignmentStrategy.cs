using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLotManagement.Strategy
{
    internal class RandomSpotAssignmentStrategy : ISpotAssignmentStrategy
    {
        private static readonly Random _random = new Random();

        public ParkingSpot FindParkingSpot(ParkingLot parkingLot, VehicleType vehicleType)
        {
            Console.WriteLine("Assigning random spot strategy");

            List<ParkingSpot> availableSpots = parkingLot.ParkingFloors
                .SelectMany(floor => floor.ParkingSpot)
                .Where(spot => spot.ParkingSpotStatus == ParkingSpotStatus.Empty && spot.SupportedVehicleTypes.Contains(vehicleType))
                .ToList();

            if (availableSpots.Count == 0)
            {
                return null;
            }

            int randomIndex = _random.Next(availableSpots.Count);
            ParkingSpot selectedSpot = availableSpots[randomIndex];
            Console.WriteLine($"Randomly selected spot: {selectedSpot.SpotNumber} for vehicle type: {vehicleType}");
            return selectedSpot;
        }
    }
}
