using OOBootCamp.ParkingLot;
using OOBootCamp.ParkingBoy;
using Xunit;

namespace TestClass.ParkingBoyFacts
{
    public class ParkingBoyFacts
    {
        [Fact]
        public void should_pick_car_after_park_car()
        {
            var car = new Car("no1");
            var parkingBoy = new ParkingBoy();
            parkingBoy.Park(car);
            Assert.Same(car, parkingBoy.PickCar());
        }
    }
}
