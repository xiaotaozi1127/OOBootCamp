using System;

namespace OOBootCamp.ParkingLot
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(params ParkingLot[] parkingLot) : base(parkingLot)
        {
        }
        
        public override ParkingInfo Park(Car car)
        {
            var vacancyRate = 0;
            ParkingLot availableParkingLot = null;

            foreach (var parkingLot in ParkingLotList)
            {
                var currentVacancyRate = parkingLot.AvaliableParkingSpots/parkingLot.Size;
                if (currentVacancyRate > vacancyRate)
                {
                    availableParkingLot = parkingLot;
                    vacancyRate = currentVacancyRate;
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
