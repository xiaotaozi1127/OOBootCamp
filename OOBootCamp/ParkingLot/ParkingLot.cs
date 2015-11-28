using System;
using System.Collections.Generic;

namespace OOBootCamp.ParkingLot
{
    public class ParkingLot
    {
        private readonly Dictionary<Guid, Car> _parkingCars;

        public readonly int Size;

        public int ParkingLotId { get; internal set; }

        public int AvaliableParkingSpots => Size - _parkingCars.Count;

        public ParkingLot(int size = 20)
        {
            Size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public ParkingLot(int id, int size)
        {
            ParkingLotId = id;
            Size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public ParkingInfo Park(Car car)
        {
            var statusCode = StatusCode.Success;
            var token = Guid.Empty;
            if (_parkingCars.ContainsValue(car))
            {
                statusCode = StatusCode.CarAlreadyParked;
            }
            if (_parkingCars.Count == Size)
            {
                statusCode = StatusCode.ParkinglotIsFull;
            }
            else
            {
                token = Guid.NewGuid();
                _parkingCars.Add(token, car);
            }
            return new ParkingInfo(ParkingLotId, token, statusCode);
        }

        public Car PickCar(Guid token)
        {
            if (!_parkingCars.ContainsKey(token)) return null;
            var result = _parkingCars[token];
            _parkingCars.Remove(token);
            return result;
        }

//        public bool IsFull()
//        {
//            return _parkingCars.Count == Size;
//        }
    }
}