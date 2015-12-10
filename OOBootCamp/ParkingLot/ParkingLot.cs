using System;
using System.Collections.Generic;

namespace OOBootCamp.ParkingLot
{
    public class ParkingLot : IParkable
    {
        private readonly Dictionary<Guid, Car> _parkingCars;

        private readonly int _size;

        public readonly Guid ParkingLotGuid;

        public int AvaliableParkingSpots => _size - _parkingCars.Count;

        public ParkingLot(int size = 20)
        {
            ParkingLotGuid = Guid.NewGuid();
            _size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public ParkingInfo Park(Car car)
        {
            var statusCode = StatusCode.Success;
            var token = Guid.Empty;
            if (_parkingCars.Count == _size)
            {
                statusCode = StatusCode.ParkinglotIsFull;
            }
            else
            {
                token = Guid.NewGuid();
                _parkingCars.Add(token, car);
            }
            return new ParkingInfo(ParkingLotGuid, token, statusCode);
        }

        public Car Pick(ParkingInfo parkingInfo)
        {
            return Pick(parkingInfo.ParkingToken);
        }

        public bool CanPark()
        {
            return AvaliableParkingSpots > 0;
        }

        public int GetTotalsize()
        {
            return _size;
        }

        public int GetParkedNumber()
        {
            return _parkingCars.Count;
        }

        public List<ParkingLot> GetParkingLotList()
        {
            return new List<ParkingLot> {this};
        }

        public Car Pick(Guid token)
        {
            if (!_parkingCars.ContainsKey(token)) return null;
            var result = _parkingCars[token];
            _parkingCars.Remove(token);
            return result;
        }
    }
}