﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

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
