using OOSession.ParkingLot;
using Xunit;

namespace TestClass.ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_get_a_car_after_park_a_car()
        {
            var mycar = new Car();
            var parkingLot = new ParkingLot();
            parkingLot.Park(mycar);
            var car = parkingLot.GetCar();
            Assert.NotNull(car);
        }
    }
}
