using System;

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
            ParkingLot availableParkingLot = null;

            foreach (var parkingLot in _parkingLotList)
            {
                if (parkingLot.AvaliableParkingSpots > avaliablity)
                {
                    availableParkingLot = parkingLot;
                    avaliablity = parkingLot.AvaliableParkingSpots;
                }
            }

            if (availableParkingLot == null)
            {
                return new ParkingInfo(0, Guid.Empty, StatusCode.ParkinglotIsFull);
            }

            var parkingInfo = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotId, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }
    }
}
