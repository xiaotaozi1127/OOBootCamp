using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class SuperParkingBoy
    {
        private readonly List<ParkingLot> _parkingLotList;

        public SuperParkingBoy(params ParkingLot[] parkingLot)
        {
            _parkingLotList = parkingLot.ToList();
        }
        
        public ParkingInfo Park(Car car)
        {
            ParkingLot availableParkingLot = null;
            var vacancyParkingRate = 0;
            foreach (var parkingLot in _parkingLotList)
            {
                var vacancyRate = parkingLot.AvaliableParkingSpots/parkingLot.Size;
                if (!parkingLot.IsFull() && vacancyRate > vacancyParkingRate)
                {
                    availableParkingLot = parkingLot;
                }
            }
            if (availableParkingLot != null)
            {
                var parkingInfo = availableParkingLot.Park(car);
                return new ParkingInfo(availableParkingLot.ParkingLotId, parkingInfo.ParkingToken, StatusCode.Success);
            }
            return new ParkingInfo(0, Guid.Empty, StatusCode.ParkinglotIsFull);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            return _parkingLotList.Single(t => t.ParkingLotId == parkingInfo.ParkingLotId).PickCar(parkingInfo.ParkingToken);
        }
    }
}
