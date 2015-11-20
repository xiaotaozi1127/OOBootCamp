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

        public ParkingLot(int size)
        {
            _size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public int ParkingLotNumber { get; internal set; }

        internal Guid Park(Car mycar)
        {
            if (_parkingCars.ContainsValue(mycar)) throw new InvalidOperationException("can not park a existed car.");
            var token = Guid.NewGuid();
            _parkingCars.Add(token, mycar);
            return token;
        }

        internal Car PickCar(Guid token)
        {
            Car result = null;
            if (_parkingCars.ContainsKey(token))
            {
                result = _parkingCars[token];
                _parkingCars.Remove(token);
            }
            return result;
        }

        internal bool NotFull()
        {
            return _parkingCars.Count < _size;
        }
    }
}