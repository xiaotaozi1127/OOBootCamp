using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoyManager
    {
        private readonly List<IParkingBoy> _availableBoys;

        public ParkingBoyManager(List<IParkingBoy> boys)
        {
            _availableBoys = boys;
        }

        public ParkingInfo Park(Car car)
        {
            var boy = _availableBoys.FirstOrDefault(t => t.CanPark());
            if (boy != null)
            {
                return boy.Park(car);
            }
            return new ParkingInfo(Guid.Empty, Guid.Empty, StatusCode.ParkinglotIsFull);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            return _availableBoys.Select(boy => boy.Pick(parkingInfo)).FirstOrDefault(car => car != null);
        }

        public string GetParkStatus()
        {
            var stringBuilder = new StringBuilder();
            
            var parkingLots = _availableBoys.Where(t => t is ParkingLot);
            var parkingBoys = _availableBoys.Where(t => (t is ParkingLot) == false);
            stringBuilder.AppendFormat("M {0} {1}\r\n", _availableBoys.Sum(t => t.GetParkedNumber()), _availableBoys.Sum(t=> t.GetTotalsize()));

            foreach (var parkingLot in parkingLots)
            {
                stringBuilder.AppendFormat("  {0}", parkingLot.GetParkStatus());
            }
            foreach (var boy in parkingBoys)
            {
                var parkStatus = boy.GetParkStatus();
                var split = parkStatus.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split.Length; i++)
                {
                    split[i] = "  " + split[i];
                    stringBuilder.AppendLine(split[i]);
                }
            }

            stringBuilder.Remove(stringBuilder.ToString().LastIndexOf("\r\n"), 2);
            return stringBuilder.ToString();
        }
    }
}