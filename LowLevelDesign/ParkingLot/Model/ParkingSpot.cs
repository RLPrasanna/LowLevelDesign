using ParkingLot.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.Model
{
    internal class ParkingSpot : BaseModel
    {
        public List<VehicleType> SupportedVehicleTypes { get; set; }
        public ParkingSpotStatus ParkingSpotStatus { get; set; }
        public int SpotNumber { get; set; }
    }
}
