using System.Collections.Generic;
using System.Linq;

namespace OOBootCamp.ParkingLot
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> _parkingLotList;

        protected ParkingBoyBase(params ParkingLot[] parkingLotList)
        {
            _parkingLotList = parkingLotList.ToList();
        }

        public abstract ParkingInfo Park(Car car);

        public Car Pick(ParkingInfo parkingInfo)
        {
            var correctParkingLot = _parkingLotList.Single(parkingLot => parkingLot.ParkingLotId == parkingInfo.ParkingLotId);
            return correctParkingLot.PickCar(parkingInfo.ParkingToken);
        }
    }
}