using ParkingLot.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Model
{
    internal class ParkingLotGate : BaseModel
    {
        public GateType GateType { get; set; }
        public int GateNumber { get; set; }
        public Operator CurrentOperator { get; set; }
        public GateStatus Status { get; set; }

        public ParkingLotGate(GateType gateType, int gateNumber, Operator currentOperator, GateStatus status)
        {
            this.GateType = gateType;
            this.GateNumber = gateNumber;
            this.CurrentOperator = currentOperator;
            this.Status = status;
        }

        public ParkingLotGate(GateType gateType, Operator currentOperator, GateStatus status)
        {
            this.GateType = gateType;
            this.CurrentOperator = currentOperator;
            this.Status = status;
        }
    }
}
