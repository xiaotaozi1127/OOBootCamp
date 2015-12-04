using System;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(params ParkingLot[] parkingLotList) : base(parkingLotList)
        {
        }

        public override ParkingInfo Park(Car car)
        {
            var availableParkingLot = ParkingLotList.FirstOrDefault(parkingLot => parkingLot.AvaliableParkingSpots > 0);
            return GetParkingInfo(car, availableParkingLot);
        }
    }
}
