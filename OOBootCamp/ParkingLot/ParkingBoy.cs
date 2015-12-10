using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return ParkingBoyHelper.CanPark(_parkingLotList);
        }

        public int GetTotalsize()
        {
            return _parkingLotList.Sum(t => t.Size);
        }

        public int GetParkedNumber()
        {
            return _parkingLotList.Sum(t => t.GetParkedNumber());
        }

        public string GetParkStatus()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("B {0} {1}\r\n", GetParkedNumber(), GetTotalsize());
            foreach (ParkingLot parkingLot in _parkingLotList)
            {
                stringBuilder.AppendFormat("  {0}", parkingLot.GetParkStatus());
            }
            return stringBuilder.ToString();
        }
    }
}
