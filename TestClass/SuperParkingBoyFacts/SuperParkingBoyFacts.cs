using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.SuperParkingBoyFacts
{
    public class SuperParkingBoyFacts
    {
        [Fact]
        public void parkingLot_should_pick_success_after_superBoy_park()
        {
            var car = new Car();
            var parkinglot = new ParkingLot();
            var superBoy = new SuperParkingBoy(parkinglot);

            var parkingInfo = superBoy.Park(car);

            Assert.Same(car, parkinglot.Pick(parkingInfo.ParkingToken));
        }

        [Fact]
        public void superBoy_should_pick_success_after_superBoy_park()
        {
            var car=new Car();
            var parkinglot = new ParkingLot();
            var superBoy = new SuperParkingBoy(parkinglot);

            var parkingInfo = superBoy.Park(car);

            Assert.Same(car,superBoy.Pick(parkingInfo));
        }

        [Fact]
        public void superBoy_should_park_failed_if_all_parkingLots_are_full()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkinglot = new ParkingLot(1);
            var superBoy = new SuperParkingBoy(parkinglot);

            superBoy.Park(bmw);

            Assert.Equal(StatusCode.ParkinglotIsFull, superBoy.Park(audi).StatusCode);
        }

        [Fact]
        public void should_park_in_anyParkingLot_for_multiple_empty_parkingLots_with_same_size()
        {
            var car = new Car();
            var superboy = new SuperParkingBoy(new ParkingLot(1, 10), new ParkingLot(2, 10));

            var parkingInfo = superboy.Park(car);

            Assert.Same(car, superboy.Pick(parkingInfo));
        }

        [Fact]
        public void should_park_in_any_parkingLot_for_multiple_empty_parkingLots_with_different_size()
        {
            var car = new Car();
            var superboy = new SuperParkingBoy(new ParkingLot(1, 10), new ParkingLot(2, 20));

            var parkingInfo = superboy.Park(car);

            Assert.Same(car, superboy.Pick(parkingInfo));
        }

        [Fact]
        public void should_park_in_parkinglot_with_high_available_spots_for_same_size_parkingLots()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkingLot1 = new ParkingLot(1, 10);
            var parkingLot2 = new ParkingLot(2, 10);
            var superboy = new SuperParkingBoy(parkingLot1, parkingLot2);

            parkingLot1.Park(bmw);
            var parkingInfo = superboy.Park(audi);

            Assert.Same(audi, parkingLot2.Pick(parkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_in_parkinglot_with_high_vacancy_rate_for_different_size_parkingLots()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkingLot1 = new ParkingLot(1, 10);
            var parkingLot2 = new ParkingLot(2, 20);
            var superboy = new SuperParkingBoy(parkingLot1, parkingLot2);

            parkingLot2.Park(bmw);
            var parkingInfo = superboy.Park(audi);

            Assert.Same(audi, parkingLot1.Pick(parkingInfo.ParkingToken));
        }
    }
}
