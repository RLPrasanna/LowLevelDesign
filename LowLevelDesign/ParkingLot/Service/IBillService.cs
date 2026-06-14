using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Service
{
    internal interface IBillService
    {
        Bill GenerateBill(string ticketNumber, int gateId);
    }
}
