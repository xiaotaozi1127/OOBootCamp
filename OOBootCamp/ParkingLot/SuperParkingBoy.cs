using System;
using OOSession.ParkingLot;

namespace OOBootCamp.ParkingLot
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(params ParkingLot[] parkingLot) : base(parkingLot)
        {
        }
        
        public override ParkingInfo Park(Car car)
        {
            ParkingLot availableParkingLot = null;
            var vacancyParkingRate = 0;
            foreach (var parkingLot in _parkingLotList)
            {
                var vacancyRate = parkingLot.AvaliableParkingSpots/parkingLot.Size;
                if (vacancyRate > vacancyParkingRate)
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
    }
}
