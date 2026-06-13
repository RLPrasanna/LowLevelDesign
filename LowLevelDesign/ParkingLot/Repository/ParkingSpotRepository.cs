using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Repository
{
    internal class ParkingSpotRepository
    {
        private Dictionary<long, ParkingSpot> parkingSpotRepository;
        private long lastSavedId;
        public ParkingSpotRepository()
        {
            this.parkingSpotRepository = new Dictionary<long, ParkingSpot>();
            this.lastSavedId = 0;
        }
        public ParkingSpot Save(ParkingSpot parkingFloor)
        {
            lastSavedId++;
            parkingFloor.Id = lastSavedId;
            parkingSpotRepository.Add(lastSavedId, parkingFloor);
            Console.WriteLine("Saved ParkingSpot with Id: " + lastSavedId);
            return parkingFloor;
        }

        public ParkingSpot GetById(long id)
        {
            if (!parkingSpotRepository.ContainsKey(id))
            {
                return null;
            }
            return parkingSpotRepository[id];

        }
    }
}
