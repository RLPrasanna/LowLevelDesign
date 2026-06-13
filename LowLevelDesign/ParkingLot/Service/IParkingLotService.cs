using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Service
{
    internal interface IParkingLotService
    {
        ParkingLot CreateParkingLot(List<ParkingFloor> parkingFloors, List<ParkingLotGate> parkingLotGates,
            ParkingLotStatus parkingLotStatus, SpotAssignmentStrategyType spotAssignmentStrategyType,
            FeeCalculatorStrategyType feeCalculatorStrategyType);
    }
}
