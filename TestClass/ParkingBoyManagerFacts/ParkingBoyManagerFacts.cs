using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.ParkingBoyManagerFacts
{
    public class ParkingBoyManagerFacts
    {
        [Fact]
        public void should_park_and_pick()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(new ParkingLot());
            var parkingInfo = manager.Park(car);
            Assert.Same(car, manager.Pick(parkingInfo));
        }

        [Fact]
        public void should_ask_parkingBoy_to_park_and_pick()
        {
            var car = new Car();
            var parkingLotForManager = new ParkingLot();
            var manager = new ParkingBoyManager(parkingLotForManager);
            var parkingLotForBoy = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLotForBoy);
            var parkingInfo = manager.ParkBy(parkingBoy, car);
            Assert.Same(car, manager.PickBy(parkingBoy, parkingInfo));
        }

        [Fact]
        public void should_ask_smart_boy_to_park_and_pick()
        {
            var car = new Car();
            var parkingLotForManager = new ParkingLot();
            var manager = new ParkingBoyManager(parkingLotForManager);
            var parkingLotForBoy = new ParkingLot();
            var smartparkingBoy = new SmartParkingBoy(parkingLotForBoy);
            var parkingInfo = manager.ParkBy(smartparkingBoy, car);
            Assert.Same(car, manager.PickBy(smartparkingBoy, parkingInfo));
        }

        [Fact]
        public void should_ask_super_boy_to_park_and_pick()
        {
            var car = new Car();
            var parkingLotForManager = new ParkingLot();
            var manager = new ParkingBoyManager(parkingLotForManager);
            var parkingLotForBoy = new ParkingLot();
            var superParkingBoy = new SuperParkingBoy(parkingLotForBoy);
            var parkingInfo = manager.ParkBy(superParkingBoy, car);
            Assert.Same(car, manager.PickBy(superParkingBoy, parkingInfo));
        }
    }
}
