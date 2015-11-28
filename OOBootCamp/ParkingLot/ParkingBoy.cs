using System;
using System.Linq;
using OOSession.ParkingLot;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(params ParkingLot[] parkingLotList) : base(parkingLotList)
        {
        }

        public override ParkingInfo Park(Car car)
        {
            var availableParkingLot = _parkingLotList.FirstOrDefault(parkingLot => parkingLot.AvaliableParkingSpots > 0);
            if (availableParkingLot == null)
            {
                return new ParkingInfo(0, Guid.Empty, StatusCode.ParkinglotIsFull);
            }

            var parkingInfo = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotId, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }
    }
}
