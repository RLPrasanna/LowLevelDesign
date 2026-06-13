using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Model
{
    internal class Vehicle : BaseModel
    {
        public string RegNo { get; set; }
        public VehicleType VehicleType { get; set; }

        public Vehicle(string regNo, VehicleType vehicleType)
        {
            this.RegNo = regNo;
            this.VehicleType = vehicleType;
        }
    }
}
