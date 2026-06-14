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
            TicketRepository ticketRepository = new TicketRepository();

            // Created Services
            ParkingLotService parkingLotService = new ParkingLotService(parkingLotRepository, parkingFloorRepository, parkingLotGateRepository, parkingSpotRepository);
            TicketService ticketService = new TicketService(ticketRepository, parkingLotRepository, parkingLotGateRepository);
            BillService billService = new BillService(ticketRepository, parkingLotGateRepository, parkingLotRepository);

            // Created Controller
            ParkingLotController parkingLotController = new ParkingLotController(parkingLotService);
            TicketController ticketController = new TicketController(ticketService);
            BillController billController = new BillController(billService);


            // Call the Controller method
            parkingLotController.CreateParkingLot(createNewParkingLot());
            Console.WriteLine("ParkingLot is created. Now Generating Ticket: ");

            TicketResponseDTO ticketResponseDTO = ticketController.GenerateTicket(
                                                        new GenerateTicketDTO(1, 1, new Vehicle("KA-01-HH-1234", VehicleType.Four_Wheeler)));
            Console.WriteLine("Ticket Number: " + ticketResponseDTO.Number);

            Console.WriteLine("\nSimulating Car leaving after some time (Generating Bill): ");
            // In reality, this would be an exit gate. Using gateId=1 for simplicity.
            BillResponseDTO billResponseDTO = billController.GenerateBill(new BillRequestDTO
            {
                TicketNumber = ticketResponseDTO.Number,
                GateId = 1
            });

            if (billResponseDTO.ResponseStatus == ResponseStatus.SUCCESS)
            {
                Console.WriteLine("Bill Generated Successfully.");
                Console.WriteLine($"Exit Time: {billResponseDTO.Bill.ExitTime}");
                Console.WriteLine($"Amount to Pay: Rs {billResponseDTO.Bill.Amount}");
            }
            else
            {
                Console.WriteLine("Failed to generate bill: " + billResponseDTO.FailureMessage);
            }
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
 