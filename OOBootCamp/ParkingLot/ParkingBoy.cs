using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy
    {
        readonly List<ParkingLot> _parkingLotList;

        public ParkingBoy(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
        }

        public void AddParkingLot(ParkingLot parkingLot)
        {
            _parkingLotList.Add(parkingLot);
            parkingLot.ParkingLotNumber = _parkingLotList.Count;
        }

        public ParkingInfo Park(Car car)
        {
            var availableParkingLot = _parkingLotList.FirstOrDefault(parkingLot => parkingLot.NotFull());
            if (availableParkingLot == null)
            {
                var statusCode = StatusCode.ParkinglotIsFull;
                return new ParkingInfo(0, Guid.Empty, statusCode);
            }

            ParkingInfo parkingInfo = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotNumber, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }

        public Car PickCar(ParkingInfo parkingInfo)
        {
            var parkedgLot = _parkingLotList.Single(parkingLot => parkingLot.ParkingLotNumber == parkingInfo.ParkingLotNumber);
            return parkedgLot.PickCar(parkingInfo.ParkingToken);
        }
    }
}
