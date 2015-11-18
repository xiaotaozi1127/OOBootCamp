using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingLotManager
    {
        readonly List<ParkingLot> _parkingLotList;

        public ParkingLotManager()
        {
            _parkingLotList = new List<ParkingLot>();
        }

        public void AddParkingLot(ParkingLot parkingLot)
        {
            _parkingLotList.Add(parkingLot);
            parkingLot.ParkingLotNumber = _parkingLotList.Count;
        }

        public ParkingLot GetAvailableParkingLot()
        {
            return _parkingLotList.FirstOrDefault(parkingLot => parkingLot.NotFull());
        }

        public ParkingLot GetParkingLotByParkingNumber(int parkingNo)
        {
            return _parkingLotList.FirstOrDefault(parkingLot => parkingLot.ParkingLotNumber == parkingNo);
        }
    }
}