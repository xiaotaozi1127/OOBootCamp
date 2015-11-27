using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCamp.SmartParkingBoyFacts
{
    public class SmartParkingBoyFacts
    {
        [Fact]
        public void parkingLot_should_get_car_after_smartBoy_park()
        {
            var bmw = new Car();
            var parkingLot = new ParkingLot.ParkingLot();
            var smartBoy = new SmartParkingBoy(parkingLot);

            var parkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, parkingLot.PickCar(parkingInfo.ParkingToken));
        }

        [Fact]
        public void smartParkingBoy_should_get_car_after_smartBoy_park()
        {
            var bmw = new Car();
            var parkingLot = new ParkingLot.ParkingLot();
            var smartBoy = new SmartParkingBoy(parkingLot);

            var parkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, smartBoy.Pick(parkingInfo));
        }

        [Fact]
        public void smartParkingBoy_should_get_car_after_parkingLot_park()
        {
            var bmw = new Car();
            var parkingLot = new ParkingLot.ParkingLot();
            var smartBoy = new SmartParkingBoy(parkingLot);

            var parkingInfo = parkingLot.Park(bmw);

            Assert.Same(bmw, smartBoy.Pick(parkingInfo));
        }

        [Fact]
        public void smartParkingBoy_should_park_fail_if_parkingLot_is_full()
        {
            var bmw = new Car();
            var parkingLot = new ParkingLot.ParkingLot(1, 1);
            var smartBoy = new SmartParkingBoy(parkingLot);
            smartBoy.Park(bmw);

            var parkingInfo = smartBoy.Park(bmw);

            Assert.Equal(StatusCode.ParkinglotIsFull, parkingInfo.StatusCode);
        }

        [Fact]
        public void should_park_success_for_same_size_empty_parkingLots()
        {
            var bmw = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot(1, 1);
            var parkingLot2 = new ParkingLot.ParkingLot(2, 1);
            var smartBoy = new SmartParkingBoy(parkingLot1, parkingLot2);

            var bmwParkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, smartBoy.Pick(bmwParkingInfo));
        }

        [Fact]
        public void should_park_in_bigger_empty_parkingLot_for_different_size_empty_parkingLots()
        {
            var bmw = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot(1, 1);
            var parkingLot2 = new ParkingLot.ParkingLot(2, 2);
            var smartBoy = new SmartParkingBoy(parkingLot1, parkingLot2);

            var bmwParkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, parkingLot2.PickCar(bmwParkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_in_unused_parkingLot_for_two_same_size_parkingLots()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot(1, 2);
            var parkingLot2 = new ParkingLot.ParkingLot(2, 2);
            var smartBoy = new SmartParkingBoy(parkingLot1, parkingLot2);
            parkingLot1.Park(bmw);

            var parkingInfo = smartBoy.Park(audi);

            Assert.Same(audi, parkingLot2.PickCar(parkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_sucess_for_parkingLot_with_same_availible_parking_spots()
        {
            var bmw = new Car();
            var audi = new Car();
            var benz = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot(1, 2);
            var parkingLot2 = new ParkingLot.ParkingLot(2, 2);
            var smartBoy = new SmartParkingBoy(parkingLot1, parkingLot2);
            parkingLot1.Park(bmw);
            parkingLot2.Park(audi);

            var parkingInfo = smartBoy.Park(benz);

            Assert.Same(benz, smartBoy.Pick(parkingInfo));
        }

        [Fact]
        public void should_park_in_more_available_parkingLot_with_different_availible_spots()
        {
            var bmw = new Car();
            var audi = new Car();
            var benz = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot(1, 2);
            var parkingLot2 = new ParkingLot.ParkingLot(2, 3);
            var smartBoy = new SmartParkingBoy(parkingLot1, parkingLot2);
            parkingLot1.Park(bmw);
            parkingLot2.Park(audi);

            var parkingInfo = smartBoy.Park(benz);

            Assert.Same(benz, parkingLot2.PickCar(parkingInfo.ParkingToken));
        }
    }
}
