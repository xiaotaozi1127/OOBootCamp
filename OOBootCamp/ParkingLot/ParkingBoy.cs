using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy : IParkable
    {
        private readonly List<ParkingLot> _parkingLotList;

        public ParkingBoy(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
        }

        public ParkingInfo Park(Car car)
        {
            var availableParkingLot = _parkingLotList.FirstOrDefault(parkingLot => parkingLot.CanPark());
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

        public int GetTotalsize()
        {
            return _parkingLotList.Sum(t => t.GetTotalsize());
        }

        public int GetParkedNumber()
        {
            return _parkingLotList.Sum(t => t.GetParkedNumber());
        }

        public List<ParkingLot> GetParkingLotList()
        {
            return _parkingLotList;
        }
    }
}
