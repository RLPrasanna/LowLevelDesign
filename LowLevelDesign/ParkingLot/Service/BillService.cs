using ParkingLotManagement.Factory;
using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using ParkingLotManagement.Repository;
using ParkingLotManagement.Strategy;
using System;

namespace ParkingLotManagement.Service
{
    internal class BillService : IBillService
    {
        private TicketRepository _ticketRepository;
        private ParkingLotGateRepository _gateRepository;
        private ParkingLotRepository _parkingLotRepository;

        public BillService(TicketRepository ticketRepository, ParkingLotGateRepository gateRepository, ParkingLotRepository parkingLotRepository)
        {
            _ticketRepository = ticketRepository;
            _gateRepository = gateRepository;
            _parkingLotRepository = parkingLotRepository;
        }

        public Bill GenerateBill(string ticketNumber, int gateId)
        {
            Ticket ticket = _ticketRepository.GetTicketByNumber(ticketNumber);
            if (ticket == null)
            {
                throw new Exception("Invalid Ticket");
            }

            ParkingLotGate gate = _gateRepository.GetById(gateId);
            if (gate == null)
            {
                throw new Exception("Invalid gate");
            }

            Model.ParkingLot parkingLot = _parkingLotRepository.GetParkingLotByGateId(gateId);
            if(parkingLot == null)
            {
                throw new Exception("Cannot find parking lot for this gate");
            }

            IFeeCalculationStrategy feeCalculationStrategy = FeeCalculationStrategyFactory.GetFeeCalculationStrategy(parkingLot.FeeCalculatorStrategyType);

            double amount = feeCalculationStrategy.CalculateFee(ticket);

            Bill bill = new Bill
            {
                ExitTime = DateTime.Now,
                Amount = (int)amount, // Simplifying for this example
                Ticket = ticket,
                Gate = gate,
                GeneratedBy = gate.CurrentOperator,
                BillStatus = BillStatus.Unpaid
            };

            // Free the spot
            ticket.AssignedSpot.ParkingSpotStatus = ParkingSpotStatus.Empty;

            return bill;
        }
    }
}
