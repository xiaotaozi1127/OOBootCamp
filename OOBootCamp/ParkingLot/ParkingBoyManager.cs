using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<IParkable> GetParableList()
        {
            return _availableBoys;
        }
    }
}