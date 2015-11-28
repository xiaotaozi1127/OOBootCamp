using System;
using OOSession.ParkingLot;

namespace OOBootCamp.ParkingLot
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public SmartParkingBoy(params ParkingLot[] parkingLotList) :base(parkingLotList)
        {
        }

        public override ParkingInfo Park(Car car)
        {
            var avaliablity = 0;
            ParkingLot bigParkingLot = null;

            foreach (var parkingLot in _parkingLotList)
            {
                if (parkingLot.AvaliableParkingSpots > avaliablity)
                {
                    bigParkingLot = parkingLot;
                    avaliablity = parkingLot.AvaliableParkingSpots;
                }
            }

            if (bigParkingLot == null)
            {
                return new ParkingInfo(0, Guid.Empty, StatusCode.ParkinglotIsFull);
            }

            ParkingInfo parkingInfo = bigParkingLot.Park(car);
            return new ParkingInfo(bigParkingLot.ParkingLotId, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }
    }
}
