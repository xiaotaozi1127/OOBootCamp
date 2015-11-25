using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class SmartParkingBoy
    {
        readonly List<ParkingLot> _parkingLotList;

        public SmartParkingBoy(params ParkingLot[] parkingLotList)
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
            var size = 0;
            var bigParkingLot = _parkingLotList[0];

            foreach (var parkingLot in _parkingLotList)
            {
                if (parkingLot.NotFull() && parkingLot.AvaliableParkingPosition > size)
                {
                    bigParkingLot = parkingLot;
                    size = parkingLot.AvaliableParkingPosition;
                }
            }

            if (bigParkingLot == null)
            {
                var statusCode = StatusCode.ParkinglotIsFull;
                return new ParkingInfo(0, Guid.Empty, statusCode);
            }

            ParkingInfo parkingInfo = bigParkingLot.Park(car);
            return new ParkingInfo(bigParkingLot.ParkingLotNumber, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }

        public Car PickCar(ParkingInfo parkingInfo)
        {
            var parkedgLot = _parkingLotList.Single(parkingLot => parkingLot.ParkingLotNumber == parkingInfo.ParkingLotNumber);
            return parkedgLot.PickCar(parkingInfo.ParkingToken);
        }
    }
}
