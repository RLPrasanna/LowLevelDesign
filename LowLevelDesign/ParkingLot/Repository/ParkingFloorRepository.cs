using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Repository
{
    internal class ParkingFloorRepository
    {
        private Dictionary<long, ParkingFloor> parkingFloorRepository;
        private long lastSavedId;
        public ParkingFloorRepository()
        {
            this.parkingFloorRepository = new Dictionary<long, ParkingFloor>();
            this.lastSavedId = 0;
        }
        public ParkingFloor Save(ParkingFloor parkingFloor)
        {
            lastSavedId++;
            parkingFloor.Id = lastSavedId;
            parkingFloorRepository.Add(lastSavedId, parkingFloor);
            Console.WriteLine("Saved ParkingFloor with Id: " + lastSavedId);
            return parkingFloor;
        }

        public ParkingFloor GetById(long id)
        {
            if (!parkingFloorRepository.ContainsKey(id))
            {
                return null;
            }
            return parkingFloorRepository[id];

        }
    }
}
