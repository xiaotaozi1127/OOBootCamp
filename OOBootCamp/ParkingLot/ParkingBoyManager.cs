using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoyManager
    {
        private readonly List<ParkingLot> _parkingLotList;

        private readonly List<IParkingBoy> _availableBoys;

        public ParkingBoyManager(List<IParkingBoy> availableBoys, params ParkingLot[] parkingLot )
        {
            _availableBoys = availableBoys;
            _parkingLotList = parkingLot?.ToList();
        }

        public ParkingInfo Park(Car car)
        {
            ParkingLot availableParkingLot = null;
            if (_parkingLotList != null)
            {
                availableParkingLot = _parkingLotList.FirstOrDefault(parkingLot => parkingLot.AvaliableParkingSpots > 0);
            }

            if (availableParkingLot == null)
            {
                IParkingBoy boy = _availableBoys.FirstOrDefault(t => t.CanPark());
                if (boy != null)
                {
                    return boy.Park(car);
                }
                return new ParkingInfo(Guid.Empty, Guid.Empty, StatusCode.ParkinglotIsFull);
            }
            return ParkingBoyHelper.GetParkingInfo(car, availableParkingLot);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            if (_parkingLotList != null && _parkingLotList.Exists(t => t.ParkingLotGuid == parkingInfo.ParkingLotGuid))
                return ParkingBoyHelper.Pick(parkingInfo, _parkingLotList);
            return _availableBoys.Select(boy => boy.Pick(parkingInfo)).FirstOrDefault(car => car != null);
        }
    }
}