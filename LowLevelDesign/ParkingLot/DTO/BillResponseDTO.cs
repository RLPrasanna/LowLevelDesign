using ParkingLotManagement.Model;
using ParkingLotManagement.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class BillResponseDTO
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string FailureMessage { get; set; }
        public Bill Bill { get; set; }
    }
}
