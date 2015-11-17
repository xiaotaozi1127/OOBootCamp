using System;
using System.Collections.Generic;

namespace OOBootCamp.ParkingLot
{
    public class ParkingLot
    {
        readonly Dictionary<Guid, Car> _parkingCars;

        public ParkingLot()
        {
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public Guid Park(Car mycar)
        {
            if (!_parkingCars.ContainsValue(mycar))
            {
                var token = Guid.NewGuid();
                _parkingCars.Add(token, mycar);
                return token;
            }
            throw new InvalidOperationException("can not park a existed car.");
        }

        public Car PickCar(Guid token)
        {
            Car result = null;
            if (_parkingCars.ContainsKey(token))
            {
                result = _parkingCars[token];
                _parkingCars.Remove(token);
            }
            return result;
        }
    }
}