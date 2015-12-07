namespace OOBootCamp.ParkingLot
{
    public interface IParkingBoy
    {
        ParkingInfo Park(Car car);
        Car Pick(ParkingInfo parkingInfo);
    }
}