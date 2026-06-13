using ParkingLotManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Repository
{
    internal class ParkingLotRepository
    {
        private Dictionary<long, ParkingLot> parkingLotRepository;
        private long lastSavedId;
        public ParkingLotRepository()
        {
            this.parkingLotRepository = new Dictionary<long, ParkingLot>();
            this.lastSavedId = 0;
        }
        public ParkingLot Save(ParkingLot parkingLot)
        {
            lastSavedId++;
            parkingLot.Id = lastSavedId;
            parkingLotRepository.Add(lastSavedId, parkingLot);
            Console.WriteLine("Saved ParkingLot with Id: " + lastSavedId);
            return parkingLot;
        }

        public ParkingLot GetById(long id)
        {
            if (!parkingLotRepository.ContainsKey(id))
            {
                return null;
            }
            return parkingLotRepository[id];

        }
    }
}
