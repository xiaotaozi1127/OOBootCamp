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
            var token = Guid.NewGuid();
            _parkingCars.Add(token, mycar);
            return token;
        }

        public Car GetCar(Guid token)
        {
            return _parkingCars.ContainsKey(token) ? _parkingCars[token] : null;
        }
    }
}