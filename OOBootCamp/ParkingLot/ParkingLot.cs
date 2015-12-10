﻿using System;
using System.Collections.Generic;

namespace OOBootCamp.ParkingLot
{
    public class ParkingLot : IParkingBoy
    {
        private readonly Dictionary<Guid, Car> _parkingCars;

        public readonly int Size;

        public readonly Guid ParkingLotGuid;

        public int AvaliableParkingSpots => Size - _parkingCars.Count;

        public ParkingLot(int size = 20)
        {
            ParkingLotGuid = Guid.NewGuid();
            Size = size;
            _parkingCars = new Dictionary<Guid, Car>();
        }

        public ParkingInfo Park(Car car)
        {
            var statusCode = StatusCode.Success;
            var token = Guid.Empty;
            if (_parkingCars.Count == Size)
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
            return Size;
        }

        public int GetParkedNumber()
        {
            return _parkingCars.Count;
        }

        public string GetParkStatus()
        {
            return string.Format("P {0} {1}\r\n", _parkingCars.Count, Size);
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