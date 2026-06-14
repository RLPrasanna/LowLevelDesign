using ParkingLotManagement.Factory;
using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using ParkingLotManagement.Repository;
using ParkingLotManagement.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Service
{
    internal class TicketService : ITicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly ParkingLotRepository _parkingLotRepository;
        private readonly ParkingLotGateRepository _parkingLotGateRepository;

        public TicketService(TicketRepository ticketRepository, ParkingLotRepository parkingLotRepository, ParkingLotGateRepository parkingLotGateRepository)
        {
            this._parkingLotRepository = parkingLotRepository;
            this._parkingLotGateRepository = parkingLotGateRepository;
            this._ticketRepository = ticketRepository;
        }

        /*
         * step-1: Get the ParkingLot using parkinglotId
         * step-2: Validate the ParkingLot
         * step-3: Get the Gate using gateId
         * step-4: Validate the Gate
         * step-5: Given the ParkingLot, get me the SpotAssignmentType
         * step-6: Get me the object of SpotAssignmentStrategy using the type --> Factory Pattern
         * step-7: We will have to assign the spot
         * step-8: Finally create the Ticket
         */
        public string GenerateTicket(long gateId, long parkingLotId, Vehicle vehicle)
        {
            ParkingLot parkingLot = _parkingLotRepository.GetById(parkingLotId);
            if (parkingLot == null)
            {
                throw new Exception("ParkingLot not found");
            }

            ParkingLotGate parkingLotGate = _parkingLotGateRepository.GetById(gateId);
            if (parkingLotGate == null)
            {
                throw new Exception("Gate not found");
            }


            Console.WriteLine($"Generating ticket for vehicle {vehicle.RegNo} at gate {parkingLotGate.GateNumber} in parking lot {parkingLot.Id}");

            SpotAssignmentStrategyType spotAssignmentStrategyType = parkingLot.SpotAssignmentStrategyType;

            ISpotAssignmentStrategy spotAssignmentStrategy = ParkingSpotAssignmentFactory.GetSpotAssignmentStrategy(spotAssignmentStrategyType);
            Console.WriteLine($"Using spot assignment strategy: {spotAssignmentStrategyType}");

            ParkingSpot assignedParkingSpot = spotAssignmentStrategy.FindParkingSpot(parkingLot, vehicle.VehicleType);

            // Finally create the ticket and persist it

            Ticket newTicket = new Ticket(
                Guid.NewGuid().ToString(),
                DateTime.Now,
                vehicle,
                assignedParkingSpot,
                parkingLotGate,
                parkingLotGate.CurrentOperator
            );

            Console.WriteLine("Created the ticket successfully.");
            Ticket savedTicket=_ticketRepository.Save(newTicket);
            return savedTicket.Number;
        }

    }
}
