using ParkingLotManagement.DTO;
using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Transformer
{
    internal class ParkingLotTranslator
    {
        public static List<ParkingFloor> Transform(List<ParkingFloorDTO> floors)
        {
            List<ParkingFloor> response = [];
            foreach(var floor in floors)
            {
                ParkingFloor parkingFloor = new ParkingFloor(floor.ParkingSpot, floor.FloorNumber);
                response.Add(parkingFloor);
            }
            return response;
        }

        public static List<ParkingLotGate> TransformGate(List<ParkingLotGateDTO> gates)
        {
            List<ParkingLotGate> response = [];
            foreach(var gate in gates)
            {
                ParkingLotGate parkingLotGate = new ParkingLotGate(gate.GateType, gate.GateNumber, gate.CurrentOperator, gate.Status);
                response.Add(parkingLotGate);
            }
            return response;
        }

        public static CreateParkingLotResponseDTO TransformParkingLot(ParkingLot createdParkingLot, CreateParkingLotRequestDTO requestDTO)
        {
            CreateParkingLotResponseDTO responseDTO = new CreateParkingLotResponseDTO();
            responseDTO.parkingLotId = createdParkingLot.Id;
            responseDTO.requestDTO = requestDTO;
            return responseDTO;
        }
    }
}
