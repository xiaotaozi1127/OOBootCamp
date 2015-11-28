using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> ParkingLotList;

        protected ParkingBoyBase(params ParkingLot[] parkingLotList)
        {
            ParkingLotList = parkingLotList.ToList();
        }

        public abstract ParkingInfo Park(Car car);

        public Car Pick(ParkingInfo parkingInfo)
        {
            var correctParkingLot = ParkingLotList.Single(parkingLot => parkingLot.ParkingLotId == parkingInfo.ParkingLotId);
            return correctParkingLot.Pick(parkingInfo.ParkingToken);
        }
    }
}