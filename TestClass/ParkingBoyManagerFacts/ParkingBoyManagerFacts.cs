using System.Collections.Generic;
using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.ParkingBoyManagerFacts
{
    public class ParkingBoyManagerFacts
    {
        [Fact]
        public void parkingLot_should_pick_after_manager_park()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(1);
            var manager = new ParkingBoyManager(null, parkingLot);

            var parkingInfo = manager.Park(car);

            Assert.Same(car, parkingLot.Pick(parkingInfo.ParkingToken));
        }

        [Fact]
        public void manager_should_park_and_pick()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(null, new ParkingLot(1));

            var parkingInfo = manager.Park(car);

            Assert.Same(car, manager.Pick(parkingInfo));
        }

        [Fact]
        public void should_ask_parkingBoy_to_park_and_pick()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { new ParkingBoy(new ParkingLot(1)) }, 
                null);

            var parkingInfo = manager.Park(car);
            Assert.Same(car, manager.Pick(parkingInfo));
        }

        [Fact]
        public void should_ask_smart_boy_to_park_and_pick()
        {
            var car = new Car();
            var smartparkingBoy = new SmartParkingBoy(new ParkingLot(1));
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { smartparkingBoy },
                null);

            var parkingInfo = manager.Park(car);
            Assert.Same(car, manager.Pick(parkingInfo));
        }

        [Fact]
        public void should_ask_super_boy_to_park_and_pick()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { new SuperParkingBoy(new ParkingLot()) },
                null);

            var parkingInfo = manager.Park(car);
            Assert.Same(car, manager.Pick(parkingInfo));
        }

        [Fact]
        public void should_pick_by_selectedBoy_when_selected_boy_park()
        {
            var car = new Car();
            var superParkingBoy = new SuperParkingBoy(new ParkingLot());
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { superParkingBoy},
                null);

            var parkingInfo = manager.Park(car);

            Assert.Same(car, superParkingBoy.Pick(parkingInfo));
        }

        [Fact]
        public void should_try_to_park_in_available_parkingLot()
        {
            var car = new Car();
            var superParkingBoy = new SuperParkingBoy(new ParkingLot(1));
            superParkingBoy.Park(new Car());
            var manager = new ParkingBoyManager(
                new List<IParkingBoy>
                {
                    new SmartParkingBoy(new ParkingLot(10)), superParkingBoy
                }, 
                null);

            var parkingInfo = manager.Park(car);
            Assert.Same(car, manager.Pick(parkingInfo));
        }
    }
}
