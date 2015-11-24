using System;
using System.Collections.Generic;

namespace OOBootCamp.ParkingLot
{
    public class ParkingLot
    {
        readonly Dictionary<Guid, Car> _parkingCars;
        private readonly int _size;

        public ParkingLot()
        {
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public ParkingLot(int number, int size)
        {
            ParkingLotNumber = number;
            _size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public int ParkingLotNumber { get; internal set; }

        public Guid Park(Car mycar)
        {
            if (_parkingCars.ContainsValue(mycar)) throw new InvalidOperationException("can not park a existed car.");
            var token = Guid.NewGuid();
            _parkingCars.Add(token, mycar);
            return token;
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

        public bool NotFull()
        {
            return _parkingCars.Count < _size;
        }
    }
}