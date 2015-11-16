using System;
using System.Collections.Generic;

namespace OOSession.ParkingLot
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
            var token = Guid.Empty;
            if (!_parkingCars.ContainsValue(mycar))
            {
                token = Guid.NewGuid();
                _parkingCars.Add(token, mycar);
            }
            return token;
        }

        public Car GetCar(Guid token)
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