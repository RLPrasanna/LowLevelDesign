using ParkingLot.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Model
{
    internal class Bill : BaseModel
    {
        public DateOnly ExitTime { get; set; }
        public int Amount { get; set; }
        public Ticket Ticket { get; set; }
        public ParkingLotGate Gate { get; set; }
        public Operator GeneratedBy { get; set; }
        public BillStatus BillStatus { get; set; }
        public List<Payment> Payments { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
