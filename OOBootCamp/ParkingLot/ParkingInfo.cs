using System;

namespace OOBootCamp.ParkingLot
{
    public class ParkingInfo
    {
        public ParkingInfo(int parkingLotNumber, Guid parkingToken, StatusCode statusCode)
        {
            StatusCode = statusCode;
            ParkingLotNumber = parkingLotNumber;
            ParkingToken = parkingToken;
        }

        public readonly int ParkingLotNumber;
        public readonly Guid ParkingToken;
        public readonly StatusCode StatusCode;
    }

    public enum StatusCode
    {
        Success,
        CarAlreadyParked,
        ParkinglotIsFull
    }
}
