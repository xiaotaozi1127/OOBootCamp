namespace OOSession.ParkingLot
{
    public class ParkingLot
    {
        Car parkCar;
        public ParkingLot()
        {
        }

        public void Park(Car mycar)
        {
            parkCar = mycar;
        }

        public Car GetCar()
        {
            return parkCar;
        }
    }
}