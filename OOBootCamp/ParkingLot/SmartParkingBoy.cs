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

            foreach (var parkingLot in ParkingLotList)
            {
                if (parkingLot.AvaliableParkingSpots > avaliablity)
                {
                    availableParkingLot = parkingLot;
                    avaliablity = parkingLot.AvaliableParkingSpots;
                }
            }
            return GetParkingInfo(car, availableParkingLot);
        }
    }
}
