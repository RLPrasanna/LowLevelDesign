using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Model
{
    internal class ParkingSpot : BaseModel
    {
        public List<VehicleType> SupportedVehicleTypes { get; set; }
        public ParkingSpotStatus ParkingSpotStatus { get; set; }
        public string SpotNumber { get; set; }

        public ParkingSpot(string spotNumber, List<VehicleType> supportedVehicleTypes)
        {
            this.SupportedVehicleTypes = supportedVehicleTypes;
            this.ParkingSpotStatus = ParkingSpotStatus.Empty;
            this.SpotNumber = spotNumber;
        }
    }
}
