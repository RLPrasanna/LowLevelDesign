using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using ParkingLotManagement.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Service
{
    internal class ParkingLotService : IParkingLotService
    {
        private readonly ParkingLotRepository _parkingLotRepository;
        private readonly ParkingFloorRepository _parkingFloorRepository;
        private readonly ParkingLotGateRepository _parkingLotGateRepository;
        private readonly ParkingSpotRepository _parkingSpotRepository;

        public ParkingLotService(ParkingLotRepository parkingLotRepostory, ParkingFloorRepository parkingFloorRepository, ParkingLotGateRepository parkingLotGateRepository, ParkingSpotRepository parkingSpotRepository)
        {
            this._parkingLotRepository = parkingLotRepostory;
            this._parkingFloorRepository = parkingFloorRepository;
            this._parkingSpotRepository = parkingSpotRepository;
            this._parkingLotGateRepository = parkingLotGateRepository;
        }

        public ParkingLot CreateParkingLot(List<ParkingFloor> parkingFloors, List<ParkingLotGate> parkingLotGates, 
                    ParkingLotStatus parkingLotStatus, SpotAssignmentStrategyType spotAssignmentStrategyType,
                    FeeCalculatorStrategyType feeCalculatorStrategyType)
        {
            Console.WriteLine("Inside CreateParkingLot Service -> ");

            // step-1: Save the Parking Floor
            foreach (var parkingFloor in parkingFloors)
            {
                // Save the parking floor to the database or perform any necessary operations
                _parkingFloorRepository.Save(parkingFloor);
                // In each floor, we will also have to persist all the parkingSpots and then put it inside ParkingSpot
                // so that Id is reflected correctly!
            }

            // step-2: Save parking lot gates
            foreach(var parkingLotGate in parkingLotGates)
            {
                _parkingLotGateRepository.Save(parkingLotGate);
            }

            // step-3: Create a parking lot and save it
            ParkingLot parkingLot = new ParkingLot(parkingFloors, parkingLotGates, parkingLotStatus, spotAssignmentStrategyType, feeCalculatorStrategyType);
            ParkingLot createdParkingLot = _parkingLotRepository.Save(parkingLot);
            return createdParkingLot;
        }
    }
}
