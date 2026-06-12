using ParkingLot.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Model
{
    internal class Payment : BaseModel
    {
        public PaymentMode PaymentMode { get; set; }
        public double Amount { get; set; }
        public DateOnly Time { get; set; }
        public string ReferenceNumber { get; set; } // payment gateway reference
    }
}
