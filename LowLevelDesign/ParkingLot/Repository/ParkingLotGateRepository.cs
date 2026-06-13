using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Repository
{
    internal class ParkingLotGateRepository
    {
        private Dictionary<long, ParkingLotGate> parkingLotGateRepository;
        private long lastSavedId;
        public ParkingLotGateRepository()
        {
            this.parkingLotGateRepository = new Dictionary<long, ParkingLotGate>();
            this.lastSavedId = 0;
        }
        public ParkingLotGate Save(ParkingLotGate parkingLotGate)
        {
            lastSavedId++;
            parkingLotGate.Id = lastSavedId;
            parkingLotGateRepository.Add(lastSavedId, parkingLotGate);
            Console.WriteLine("Saved ParkingLotGate with Id: " + lastSavedId);
            return parkingLotGate;
        }

        public ParkingLotGate GetById(long id)
        {
            if (!parkingLotGateRepository.ContainsKey(id))
            {
                return null;
            }
            return parkingLotGateRepository[id];

        }
    }
}
