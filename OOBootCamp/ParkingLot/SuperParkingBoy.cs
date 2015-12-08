using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class SuperParkingBoy : IParkingBoy
    {
        private readonly List<ParkingLot> _parkingLotList;

        public SuperParkingBoy(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
        }
        
        public ParkingInfo Park(Car car)
        {
            var vacancyRate = 0;
            ParkingLot availableParkingLot = null;

            foreach (var parkingLot in _parkingLotList)
            {
                var currentVacancyRate = parkingLot.AvaliableParkingSpots/parkingLot.Size;
                if (currentVacancyRate > vacancyRate)
                {
                    availableParkingLot = parkingLot;
                    vacancyRate = currentVacancyRate;
                }
            }
            return ParkingBoyHelper.GetParkingInfo(car, availableParkingLot);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            return ParkingBoyHelper.Pick(parkingInfo, _parkingLotList);
        }

        public bool CanPark()
        {
            return ParkingBoyHelper.CanPark(_parkingLotList);
        }
    }
}
