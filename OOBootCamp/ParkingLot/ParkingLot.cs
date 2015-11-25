using System;
using System.Collections.Generic;

namespace OOBootCamp.ParkingLot
{
    public class ParkingLot
    {
        readonly Dictionary<Guid, Car> _parkingCars;
        public readonly int _size;

        public ParkingLot(int size = 20)
        {
            _size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public ParkingLot(int number, int size)
        {
            ParkingLotNumber = number;
            _size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public int ParkingLotNumber { get; internal set; }

        public ParkingInfo Park(Car car)
        {
            var statusCode = StatusCode.Success;
            Guid token = Guid.Empty;
            if (_parkingCars.ContainsValue(car))
            {
                statusCode = StatusCode.CarAlreadyParked;
            }
            if (!NotFull())
            {
                statusCode = StatusCode.ParkinglotIsFull;
            }
            else
            {
                token = Guid.NewGuid();
                _parkingCars.Add(token, car);
            }
            return new ParkingInfo(ParkingLotNumber, token, statusCode);
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

        public int AvaliableParkingPosition
        {
            get { return _size - _parkingCars.Count; }
        }


    }
}