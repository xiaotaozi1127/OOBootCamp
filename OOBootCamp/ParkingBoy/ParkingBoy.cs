using OOBootCamp.ParkingLot;

namespace OOBootCamp.ParkingBoy
{
    public class ParkingBoy
    {
        Car _car;

        public void Park(Car car)
        {
            _car = car;
        }

        public Car PickCar()
        {
            return _car;
        }
    }
}
