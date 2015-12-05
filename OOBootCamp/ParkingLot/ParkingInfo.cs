using System;

namespace OOBootCamp.ParkingLot
{
    public class ParkingInfo
    {
        public ParkingInfo(Guid parkingLotGuid, Guid parkingToken, StatusCode statusCode)
        {
            ParkingLotGuid = parkingLotGuid;
            StatusCode = statusCode;
            ParkingToken = parkingToken;
        }

        public readonly Guid ParkingLotGuid;
        public readonly Guid ParkingToken;
        public readonly StatusCode StatusCode;
    }

    public enum StatusCode
    {
        Success,
        ParkinglotIsFull
    }
}
