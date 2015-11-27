using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class SmartParkingBoy
    {
        private readonly List<ParkingLot> _parkingLotList;

        public SmartParkingBoy(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
        }

        public ParkingInfo Park(Car car)
        {
            var size = 0;
            ParkingLot bigParkingLot = null;

            foreach (var parkingLot in _parkingLotList)
            {
                if (!parkingLot.IsFull() && parkingLot.AvaliableParkingSpots > size)
                {
                    bigParkingLot = parkingLot;
                    size = parkingLot.AvaliableParkingSpots;
                }
            }

            if (bigParkingLot == null)
            {
                return new ParkingInfo(0, Guid.Empty, StatusCode.ParkinglotIsFull);
            }

            ParkingInfo parkingInfo = bigParkingLot.Park(car);
            return new ParkingInfo(bigParkingLot.ParkingLotId, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            var correctParkingLot = _parkingLotList.Single(parkingLot => parkingLot.ParkingLotId == parkingInfo.ParkingLotId);
            return correctParkingLot.PickCar(parkingInfo.ParkingToken);
        }
    }
}
