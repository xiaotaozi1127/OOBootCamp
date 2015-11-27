using System;
using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCamp.ParkingBoyFacts
{
    public class ParkingBoyFacts
    {
        [Fact]
        public void should_pick_car_success_after_park_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot.ParkingLot(1, 1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var parkingInfo = parkingBoy.Park(car);
            Assert.Same(car, parkingBoy.Pick(parkingInfo));
        }

        [Fact]
        public void should_park_car_to_first_parkingLot_if_it_is_not_full()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkingLot = new ParkingLot.ParkingLot(1, 2);

            var parkingBoy = new ParkingBoy(parkingLot, new ParkingLot.ParkingLot(2, 2));

            var bmwParkingInfo = parkingBoy.Park(bmw);
            var audiParkingInfo = parkingBoy.Park(audi);

            Assert.Same(bmw, parkingLot.PickCar(bmwParkingInfo.ParkingToken));
            Assert.Same(audi, parkingLot.PickCar(audiParkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_car_to_second_parkingLot_if_the_first_parkingLot_is_full()
        {
            var bmw = new Car();
            var audi = new Car();

            var parkingLot1 = new ParkingLot.ParkingLot(1, 1);
            var parkingLot2 = new ParkingLot.ParkingLot(2, 1);
            var parkingBoy = new ParkingBoy(parkingLot1, parkingLot2);

            var bmwParkingInfo = parkingBoy.Park(bmw);
            var audiParkingInfo = parkingBoy.Park(audi);

            Assert.Same(bmw, parkingLot1.PickCar(bmwParkingInfo.ParkingToken));
            Assert.Same(audi, parkingLot2.PickCar(audiParkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_car_to_first_available_parkingLot_if_there_are_mutiple_available_parkingLots()
        {
            var bmw = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot(1, 1);
            var parkingLot2 = new ParkingLot.ParkingLot(1, 1);
            var parkingBoy = new ParkingBoy(parkingLot1, parkingLot2);

            var bmwParkingInfo = parkingBoy.Park(bmw);

            Assert.Same(bmw, parkingLot1.PickCar(bmwParkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_car_fail_when_all_parkingLots_are_full()
        {
            var parkingBoy = new ParkingBoy(new ParkingLot.ParkingLot(1, 1));
            parkingBoy.Park(new Car());

            var parkingInfo = parkingBoy.Park(new Car());
            Assert.Equal(StatusCode.ParkinglotIsFull, parkingInfo.StatusCode);
        }
    }
}