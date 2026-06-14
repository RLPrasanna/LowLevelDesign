using ParkingLotManagement.Model;
using System;

namespace ParkingLotManagement.Strategy
{
    internal class StaticFeeCalculationStrategy : IFeeCalculationStrategy
    {
        public double CalculateFee(Ticket ticket)
        {
            // Simple logic: Base fee + hourly rate based on vehicle type
            double baseFee = 20.0;
            double hourlyRate = 10.0;

            if (ticket.Vehicle.VehicleType == Model.Enums.VehicleType.Four_Wheeler)
            {
                baseFee = 50.0;
                hourlyRate = 25.0;
            }
            else if (ticket.Vehicle.VehicleType == Model.Enums.VehicleType.Two_Wheeler)
            {
                baseFee = 10.0;
                hourlyRate = 5.0;
            }

            TimeSpan parkedDuration = DateTime.Now - ticket.EntryTime;
            double hoursParked = Math.Ceiling(parkedDuration.TotalHours);

            if (hoursParked < 1) hoursParked = 1;

            return baseFee + (hoursParked * hourlyRate);
        }
    }
}
