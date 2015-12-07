using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy : IParkingBoy
    {
        private readonly List<ParkingLot> _parkingLotList;

        public ParkingBoy(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
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

        public bool CanPark()
        {
            return _parkingLotList.Exists(t => t.AvaliableParkingSpots > 0);
        }
    }
}
