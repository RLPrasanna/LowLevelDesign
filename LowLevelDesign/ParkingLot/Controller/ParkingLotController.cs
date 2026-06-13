using ParkingLotManagement.DTO;
using ParkingLotManagement.Exceptions;
using ParkingLotManagement.Model;
using ParkingLotManagement.Service;
using ParkingLotManagement.Transformer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Controller
{
    internal class ParkingLotController
    {
        private readonly ParkingLotService service;

        public ParkingLotController(ParkingLotService service)
        {
            this.service = service;
        }

        public CreateParkingLotResponseDTO CreateParkingLot(CreateParkingLotRequestDTO request)
        {
            Console.WriteLine("Inside CreateParkingLot -> ");
            // step-1: Validate the input
            if (!isValidInput(request)){
                Console.WriteLine("Invalid input for Request DTO: " + request);
                throw new InvalidParameterException();
            }

            // step-2: Call the service layer
            ParkingLot parkingLot = this.service.CreateParkingLot(
                                        ParkingLotTranslator.Transform(request.ParkingFloors),
                                        ParkingLotTranslator.TransformGate(request.ParkingLotGates),
                                        request.ParkingLotStatus, request.SpotAssignmentStrategyType,
                                        request.FeeCalculatorStrategyType);

            // step-3: Convert ParkingLot to DTO and return
            Console.WriteLine("Returning response from controller: " + parkingLot);
            return ParkingLotTranslator.TransformParkingLot(parkingLot,request);
        }

        private bool isValidInput(CreateParkingLotRequestDTO request)
        {
            if (request == null)
            {
                return false;
            }
            return true;
        }
    }
}
