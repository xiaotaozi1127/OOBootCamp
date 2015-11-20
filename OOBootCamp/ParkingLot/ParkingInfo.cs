using System;

namespace OOBootCamp.ParkingLot
{
    public class ParkingInfo
    {
        public ParkingInfo(int parkingLotNumber, Guid parkingToken)
        {
            ParkingLotNumber = parkingLotNumber;
            ParkingToken = parkingToken;
        }

        public readonly int ParkingLotNumber;
        public readonly Guid ParkingToken;
    }
}
