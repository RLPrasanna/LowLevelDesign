using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class CreateParkingLotRequestDTO
    {
        public List<ParkingFloorDTO> ParkingFloors { get; set; }
        public List<ParkingLotGateDTO> ParkingLotGates { get; set; }
        public ParkingLotStatus ParkingLotStatus { get; set; }
        public SpotAssignmentStrategyType SpotAssignmentStrategyType { get; set; }
        public FeeCalculatorStrategyType FeeCalculatorStrategyType { get; set; }
    }
}
