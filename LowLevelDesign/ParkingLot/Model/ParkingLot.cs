using ParkingLot.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Model
{
    internal class ParkingLot : BaseModel
    {
        public List<ParkingFloor> ParkingFloors { get; set; }
        public List<ParkingLotGate> ParkingLotGates { get; set; }
        public ParkingLotStatus ParkingLotStatus { get; set; }

    }
}
