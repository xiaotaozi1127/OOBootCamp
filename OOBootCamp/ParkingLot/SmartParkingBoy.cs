using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class SmartParkingBoy : IParkingBoy
    {
        private readonly List<ParkingLot> _parkingLotList;

        public SmartParkingBoy(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
        }

        public ParkingInfo Park(Car car)
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
            return ParkingBoyHelper.GetParkingInfo(car, availableParkingLot);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            return ParkingBoyHelper.Pick(parkingInfo, _parkingLotList);
        }
    }
}
