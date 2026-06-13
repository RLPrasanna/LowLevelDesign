using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class ParkingLotGateDTO
    {
        public GateType GateType { get; set; }
        public int GateNumber { get; set; }
        public Operator CurrentOperator { get; set; }
        public GateStatus Status { get; set; }

        public ParkingLotGateDTO(GateType gateType, int gateNumber, Operator currentOperator, GateStatus status)
        {
            this.GateType = gateType;
            this.GateNumber = gateNumber;
            this.CurrentOperator = currentOperator;
            this.Status = status;
        }
    }
}
