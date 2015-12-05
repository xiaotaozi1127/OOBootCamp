using System;
using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoyHelper
    {
        public static Car Pick(ParkingInfo parkingInfo, List<ParkingLot> parkingLotList )
        {
            var correctParkingLot = parkingLotList.Single(parkingLot => parkingLot.ParkingLotGuid == parkingInfo.ParkingLotGuid);
            return correctParkingLot.Pick(parkingInfo.ParkingToken);
        }

        public static ParkingInfo GetParkingInfo(Car car, ParkingLot availableParkingLot)
        {
            if (availableParkingLot == null)
            {
                return new ParkingInfo(Guid.Empty, Guid.Empty, StatusCode.ParkinglotIsFull);
            }

            var parkingInfo = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotGuid, parkingInfo.ParkingToken, parkingInfo.StatusCode);
        }
    }
}