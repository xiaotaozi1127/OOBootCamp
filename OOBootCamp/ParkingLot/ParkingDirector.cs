using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOBootCamp.ParkingLot
{
    public class ParkingDirector
    {
        private ParkingBoyManager _manager;

        readonly List<IParkable> _parkableList;

        public ParkingDirector(ParkingBoyManager manager)
        {
            _manager = manager;
            _parkableList = manager.GetParableList();
        }

        public string GetParkStatus()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("M {0} {1}\r\n", _parkableList.Sum(t => t.GetParkedNumber()), _parkableList.Sum(t=> t.GetTotalsize()));

            var parkingLots = _parkableList.Where(t => t is ParkingLot).ToList();
            AppendParkingLots(stringBuilder, parkingLots, "  ");

            var parkingBoys = _parkableList.Except(parkingLots).ToList();
            GetParkingBoyStatus(stringBuilder, parkingBoys);

            stringBuilder.Remove(stringBuilder.ToString().LastIndexOf("\r\n", StringComparison.CurrentCultureIgnoreCase), 2);
            return stringBuilder.ToString();
        }

        private void GetParkingBoyStatus(StringBuilder stringBuilder, List<IParkable> parkingBoys)
        {
            foreach (var boy in parkingBoys)
            {
                AppendParkable(stringBuilder, "  ", boy, "B");
                var parkinglots = boy.GetParkingLotList();
                AppendParkingLots(stringBuilder, parkinglots, "    ");
            }
        }

        public static void AppendParkingLots(StringBuilder stringBuilder, IEnumerable<IParkable> parkinglots, string prefix)
        {
            foreach (var parkinglot in parkinglots)
            {
                AppendParkable(stringBuilder, prefix, parkinglot, "P");
            }
        }

        private static void AppendParkable(StringBuilder stringBuilder, string prefix, IParkable parkinglot, string flag)
        {
            stringBuilder.AppendFormat("{2}{3} {0} {1}\r\n", parkinglot.GetParkedNumber(), parkinglot.GetTotalsize(), prefix, flag);
        }
    }
}