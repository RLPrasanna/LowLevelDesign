using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.DTO
{
    internal class CreateParkingLotResponseDTO
    {
        public long parkingLotId { get; set; }
        public CreateParkingLotRequestDTO requestDTO { get; set; }
    }
}
