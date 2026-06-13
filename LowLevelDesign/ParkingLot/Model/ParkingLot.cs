using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Model
{
    internal class ParkingLot : BaseModel
    {
        public List<ParkingFloor> ParkingFloors { get; set; }
        public List<ParkingLotGate> ParkingLotGates { get; set; }
        public ParkingLotStatus ParkingLotStatus { get; set; }

        public SpotAssignmentStrategyType SpotAssignmentStrategyType { get; set; }
        public FeeCalculatorStrategyType FeeCalculatorStrategyType { get; set; }

        public ParkingLot(List<ParkingFloor> parkingFloors, List<ParkingLotGate> parkingLotGates, 
            ParkingLotStatus parkingLotStatus, SpotAssignmentStrategyType spotAssignmentStrategyType,
            FeeCalculatorStrategyType feeCalculatorStrategyType)
        {
            this.ParkingFloors = parkingFloors;
            this.ParkingLotGates = parkingLotGates;
            this.ParkingLotStatus = parkingLotStatus;
            this.SpotAssignmentStrategyType = spotAssignmentStrategyType;
            this.FeeCalculatorStrategyType = feeCalculatorStrategyType;
        }
    }
}
