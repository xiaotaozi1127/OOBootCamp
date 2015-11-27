using OOBootCamp.ParkingLot;
using Xunit;

namespace TestClass
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

            Assert.Same(car, parkinglot.PickCar(parkingInfo.ParkingToken));
        }

        [Fact]
        public void superBoy_should_pick_success_after_superBoy_park()
        {
            var car=new Car();
            var parkinglot=new ParkingLot();
            var superBoy=new SuperParkingBoy(parkinglot);

            var parkingInfo = superBoy.Park(car);

            Assert.Same(car,superBoy.PickCar(parkingInfo));
        }

        [Fact]
        public void should_park_failed_if_all_parkingLots_are_full()
        {
            var car = new Car();
            var audi = new Car();
            var parkinglot = new ParkingLot(1);
            var superBoy = new SuperParkingBoy(parkinglot);

            superBoy.Park(car);

            Assert.Equal(StatusCode.ParkinglotIsFull, superBoy.Park(audi).StatusCode);
        }

        [Fact]
        public void should_park_and_pick_success_for_two_empty_same_size_parkingLots()
        {
            var car = new Car();
            var superboy = new SuperParkingBoy(new ParkingLot(1, 1), new ParkingLot(2, 1));

            var parkingInfo = superboy.Park(car);

            Assert.Same(car, superboy.PickCar(parkingInfo));
        }

        [Fact]
        public void should_park_and_pick_success_for_two_empty_different_size_parkingLots()
        {
            var car = new Car();
            var superboy = new SuperParkingBoy(new ParkingLot(1, 10), new ParkingLot(2, 20));

            var parkingInfo = superboy.Park(car);

            Assert.Same(car, superboy.PickCar(parkingInfo));
        }

        [Fact]
        public void should_park_in_parkinglot_whith_high_available_spots_for_same_size_parkingLots()
        {
            var bmw = new Car();
            var audi = new Car();

            var parkingLot1 = new ParkingLot(1, 10);
            var parkingLot2 = new ParkingLot(2, 10);
            var superboy = new SuperParkingBoy(parkingLot1, parkingLot2);

            parkingLot1.Park(bmw);
            var parkingInfo = superboy.Park(audi);

            Assert.Same(audi, parkingLot2.PickCar(parkingInfo.ParkingToken));
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

            Assert.Same(audi, parkingLot1.PickCar(parkingInfo.ParkingToken));
        }
    }
}
