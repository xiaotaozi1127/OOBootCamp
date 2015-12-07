using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoyManager
    {
        private readonly List<ParkingLot> _parkingLotList;

        public ParkingBoyManager(params ParkingLot[] parkingLot)
        {
            _parkingLotList = parkingLot.ToList();
        }

        public ParkingInfo Park(Car car)
        {
            var availableParkingLot = _parkingLotList.FirstOrDefault(parkingLot => parkingLot.AvaliableParkingSpots > 0);
            return ParkingBoyHelper.GetParkingInfo(car, availableParkingLot);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            return ParkingBoyHelper.Pick(parkingInfo, _parkingLotList);
        }

        public ParkingInfo ParkBy(IParkingBoy parkingBoy, Car car)
        {
            return parkingBoy.Park(car);
        }

        public Car PickBy(IParkingBoy parkingBoy, ParkingInfo parkingInfo)
        {
            return parkingBoy.Pick(parkingInfo);
        }
    }
}