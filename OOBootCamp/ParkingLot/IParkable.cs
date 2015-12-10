using System.Collections.Generic;

namespace OOBootCamp.ParkingLot
{
    public interface IParkable
    {
        ParkingInfo Park(Car car);
        Car Pick(ParkingInfo parkingInfo);

        bool CanPark();
        int GetTotalsize();
        int GetParkedNumber();
        List<ParkingLot> GetParkingLotList();
    }
}