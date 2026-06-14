using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Strategy
{
    internal interface IFeeCalculationStrategy
    {
        double CalculateFee(Ticket ticket);
    }
}
