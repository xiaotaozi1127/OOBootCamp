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

            Assert.Same(car, parkingLot.Pick(manager.Park(car).ParkingToken));
        }

        [Fact]
        public void manager_should_park_and_pick()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(null, new ParkingLot(1));

            Assert.Same(car, manager.Pick(manager.Park(car)));
        }

        [Fact]
        public void should_ask_parkingBoy_to_park()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { new ParkingBoy(new ParkingLot(1)) }, 
                null);

            Assert.Same(car, manager.Pick(manager.Park(car)));
        }

        [Fact]
        public void should_ask_smart_boy_to_park()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { new SmartParkingBoy(new ParkingLot(1)) },
                null);

            Assert.Same(car, manager.Pick(manager.Park(car)));
        }

        [Fact]
        public void should_ask_super_boy_to_park()
        {
            var car = new Car();
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { new SuperParkingBoy(new ParkingLot()) },
                null);

            Assert.Same(car, manager.Pick(manager.Park(car)));
        }

        [Fact]
        public void should_pick_by_selectedBoy_when_selected_boy_park()
        {
            var car = new Car();
            var superParkingBoy = new SuperParkingBoy(new ParkingLot());
            var manager = new ParkingBoyManager(
                new List<IParkingBoy> { superParkingBoy},
                null);

            Assert.Same(car, superParkingBoy.Pick(manager.Park(car)));
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
                    superParkingBoy, new SmartParkingBoy(new ParkingLot(10))
                }, 
                null);

            Assert.Same(car, manager.Pick(manager.Park(car)));
        }

        [Fact]
        public void should_park_failed_if_available_parkingLot_is_null()
        {
            var car = new Car();
            var smartParkingBoy = new SmartParkingBoy(new ParkingLot(1));
            smartParkingBoy.Park(new Car());
            var superParkingBoy = new SuperParkingBoy(new ParkingLot(1));
            superParkingBoy.Park(new Car());
            var manager = new ParkingBoyManager(
                new List<IParkingBoy>
                {
                    smartParkingBoy, superParkingBoy
                },
                null);

            Assert.Equal(StatusCode.ParkinglotIsFull, manager.Park(car).StatusCode);
        }
    }
}
