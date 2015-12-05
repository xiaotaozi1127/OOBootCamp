using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> ParkingLotList;

        protected ParkingBoyBase(params ParkingLot[] parkingLotList)
        {
            ParkingLotList = parkingLotList.ToList();
        }

        public abstract ParkingInfo Park(Car car);

        public Car Pick(ParkingInfo parkingInfo)
        {
            var correctParkingLot = ParkingLotList.Single(parkingLot => parkingLot.ParkingLotGuid == parkingInfo.ParkingLotGuid);
            return correctParkingLot.Pick(parkingInfo.ParkingToken);
        }

        protected ParkingInfo GetParkingInfo(Car car, ParkingLot availableParkingLot)
        {
            if (availableParkingLot == null)
            {
                return new ParkingInfo(Guid.Empty, Guid.Empty, StatusCode.ParkinglotIsFull);
            }

            var parkingInfo = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotGuid, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }
    }
}