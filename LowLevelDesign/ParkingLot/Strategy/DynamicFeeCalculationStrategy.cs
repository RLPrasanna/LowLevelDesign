using ParkingLotManagement.Model;
using System;

namespace ParkingLotManagement.Strategy
{
    internal class DynamicFeeCalculationStrategy : IFeeCalculationStrategy
    {
        public double CalculateFee(Ticket ticket)
        {
            // Just a slightly different logic to demonstrate dynamic
            TimeSpan parkedDuration = DateTime.Now - ticket.EntryTime;
            double hoursParked = Math.Ceiling(parkedDuration.TotalHours);

            if (hoursParked < 1) hoursParked = 1;

            double multiplier = 1.0;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                multiplier = 1.5; // Weekend surge
            }

            double hourlyRate = 15.0;
            if (ticket.Vehicle.VehicleType == Model.Enums.VehicleType.Four_Wheeler) hourlyRate = 30.0;
            else if (ticket.Vehicle.VehicleType == Model.Enums.VehicleType.Two_Wheeler) hourlyRate = 5.0;

            return (hoursParked * hourlyRate) * multiplier;
        }
    }
}
