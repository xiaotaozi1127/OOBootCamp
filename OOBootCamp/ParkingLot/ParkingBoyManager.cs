using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoyManager
    {
        private readonly List<IParkable> _availableBoys;

        public ParkingBoyManager(List<IParkable> boys)
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
            stringBuilder.AppendFormat("M {0} {1}\r\n", _availableBoys.Sum(t => t.GetParkedNumber()), _availableBoys.Sum(t=> t.GetTotalsize()));

            var parkingLots = _availableBoys.Where(t => t is ParkingLot).ToList();
            GetParkingLotStatus(stringBuilder, parkingLots);

            var parkingBoys = _availableBoys.Except(parkingLots).ToList();
            GetParkingBoyStatus(stringBuilder, parkingBoys);

            stringBuilder.Remove(stringBuilder.ToString().LastIndexOf("\r\n", StringComparison.CurrentCultureIgnoreCase), 2);
            return stringBuilder.ToString();
        }

        private void GetParkingBoyStatus(StringBuilder stringBuilder, List<IParkable> parkingBoys)
        {
            foreach (var boy in parkingBoys)
            {
                stringBuilder.AppendFormat("  B {0} {1}\r\n", boy.GetParkedNumber(), boy.GetTotalsize());
                var parkinglots = boy.GetParkingLotList();
                foreach (var parkinglot in parkinglots)
                {
                    stringBuilder.AppendFormat("    P {0} {1}\r\n", parkinglot.GetParkedNumber(), parkinglot.GetTotalsize());
                }
            }
        }

        private void GetParkingLotStatus(StringBuilder stringBuilder, List<IParkable> parkingLots)
        {
            foreach (var parkingLot in parkingLots)
            {
                stringBuilder.AppendFormat("  P {0} {1}\r\n", parkingLot.GetParkedNumber(), parkingLot.GetTotalsize());
            }
        }
    }
}