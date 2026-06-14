using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingLotManagement.Strategy
{
    internal class ManualSpotAssignmentStrategy : ISpotAssignmentStrategy
    {
        public ParkingSpot FindParkingSpot(ParkingLot parkingLot, VehicleType vehicleType)
        {
            Console.WriteLine("Assigning manual spot strategy");

            List<ParkingSpot> availableSpots = parkingLot.ParkingFloors
                .SelectMany(floor => floor.ParkingSpot)
                .Where(spot => spot.ParkingSpotStatus == ParkingSpotStatus.Empty && spot.SupportedVehicleTypes.Contains(vehicleType))
                .ToList();

            if (availableSpots.Count == 0)
            {
                Console.WriteLine($"No available spots for vehicle type: {vehicleType}");
                return null;
            }

            Console.WriteLine($"Available spots for {vehicleType}: {string.Join(", ", availableSpots.Select(x => x.SpotNumber))}");
            Console.Write("Enter preferred spot number: ");
            string selectedSpotNumber = Console.ReadLine()?.Trim();

            ParkingSpot selectedSpot = availableSpots
                .FirstOrDefault(spot => string.Equals(spot.SpotNumber, selectedSpotNumber, StringComparison.OrdinalIgnoreCase));

            if (selectedSpot == null)
            {
                Console.WriteLine($"Invalid spot selection: {selectedSpotNumber}");
                return null;
            }

            Console.WriteLine($"Manually selected spot: {selectedSpot.SpotNumber} for vehicle type: {vehicleType}");
            return selectedSpot;
        }
    }
}
