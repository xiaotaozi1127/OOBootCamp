using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> _parkingLotList;

        public ParkingBoy(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
        }

        public ParkingInfo Park(Car car)
        {
            var availableParkingLot = _parkingLotList.FirstOrDefault(parkingLot => !parkingLot.IsFull());
            if (availableParkingLot == null)
            {
                return new ParkingInfo(0, Guid.Empty, StatusCode.ParkinglotIsFull);
            }

            var parkingInfo = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotId, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            var correctParkingLot = _parkingLotList.Single(parkingLot => parkingLot.ParkingLotId == parkingInfo.ParkingLotId);
            return correctParkingLot.PickCar(parkingInfo.ParkingToken);
        }
    }
}
