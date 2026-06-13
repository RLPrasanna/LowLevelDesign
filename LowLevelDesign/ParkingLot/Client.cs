using ParkingLotManagement.Controller;
using ParkingLotManagement.DTO;
using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using ParkingLotManagement.Repository;
using ParkingLotManagement.Service;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ParkingLotManagement
{
    internal class Client
    {
        public static void Main(string[] args)
        {
            // Initialize parking lot with 2 floors, each having 2 small, 2 medium and 2 large parking spots

            // Created Repositories
            ParkingFloorRepository parkingFloorRepository = new ParkingFloorRepository();
            ParkingLotRepository parkingLotRepository = new ParkingLotRepository();
            ParkingSpotRepository parkingSpotRepository = new ParkingSpotRepository();
            ParkingLotGateRepository parkingLotGateRepository = new ParkingLotGateRepository();

            // Created Services
            ParkingLotService parkingLotService = new ParkingLotService(parkingLotRepository, parkingFloorRepository, parkingLotGateRepository, parkingSpotRepository);

            // Created Controller
            ParkingLotController parkingLotController = new ParkingLotController(parkingLotService);


            // Call the Controller method
            parkingLotController.CreateParkingLot(createNewParkingLot());
            Console.WriteLine("ParkingLot is created.");

        }


        private static CreateParkingLotRequestDTO createNewParkingLot()
        {
            CreateParkingLotRequestDTO requestDTO = new CreateParkingLotRequestDTO();
            requestDTO.FeeCalculatorStrategyType = FeeCalculatorStrategyType.Static;
            requestDTO.ParkingFloors = createParkingFloor();
            requestDTO.ParkingLotGates = createNewGate();
            requestDTO.ParkingLotStatus = ParkingLotStatus.Open;
            requestDTO.SpotAssignmentStrategyType = SpotAssignmentStrategyType.Assign_First_Empty;
            return requestDTO;
        }

        private static List<ParkingFloorDTO> createParkingFloor()
        {
            List<ParkingSpot> parkingSpots = [];
            parkingSpots.Add(new Model.ParkingSpot("1", [VehicleType.Four_Wheeler]));
            return [new ParkingFloorDTO(parkingSpots, "F1")];
        }

        private static List<ParkingLotGateDTO> createNewGate()
        {
            return [new ParkingLotGateDTO(GateType.Entry, 1, new Operator(100, "Yash"), GateStatus.Open)];
        }
    }
}
 