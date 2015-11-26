using System;

namespace OOBootCamp.ParkingLot
{
    public class ParkingInfo
    {
        public ParkingInfo(int parkingLotId, Guid parkingToken, StatusCode statusCode)
        {
            StatusCode = statusCode;
            ParkingLotId = parkingLotId;
            ParkingToken = parkingToken;
        }

        public readonly int ParkingLotId;
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
