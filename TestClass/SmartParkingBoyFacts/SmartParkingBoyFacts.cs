using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.SmartParkingBoyFacts
{
    public class SmartParkingBoyFacts
    {
        [Fact]
        public void parkingLot_should_get_car_after_smartBoy_park()
        {
            var bmw = new Car();
            var parkingLot = new ParkingLot();
            var smartBoy = new SmartParkingBoy(parkingLot);

            var parkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, parkingLot.Pick(parkingInfo.ParkingToken));
        }

        [Fact]
        public void smartBoy_should_get_car_after_smartBoy_park()
        {
            var bmw = new Car();
            var parkingLot = new ParkingLot();
            var smartBoy = new SmartParkingBoy(parkingLot);

            var parkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, smartBoy.Pick(parkingInfo));
        }

        [Fact]
        public void smartBoy_should_park_fail_if_parkingLot_is_full()
        {
            var bmw = new Car();
            var smartBoy = new SmartParkingBoy(new ParkingLot(1, 1));
            smartBoy.Park(bmw);

            var parkingInfo = smartBoy.Park(bmw);

            Assert.Equal(StatusCode.ParkinglotIsFull, parkingInfo.StatusCode);
        }

        [Fact]
        public void should_park_to_any_parkingLot_for_same_size_empty_parkingLots()
        {
            var bmw = new Car();
            var smartBoy = new SmartParkingBoy(new ParkingLot(1, 1), new ParkingLot(2, 1));

            var bmwParkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, smartBoy.Pick(bmwParkingInfo));
        }

        [Fact]
        public void should_park_in_bigger_parkingLot_for_different_size_empty_parkingLots()
        {
            var bmw = new Car();
            var parkingLot1 = new ParkingLot(1, 1);
            var parkingLot2 = new ParkingLot(2, 2);
            var smartBoy = new SmartParkingBoy(parkingLot1, parkingLot2);

            var bmwParkingInfo = smartBoy.Park(bmw);

            Assert.Same(bmw, parkingLot2.Pick(bmwParkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_in_parkingLot_with_high_availability_for_multiple_parkinglots_with_different_availibility()
        {
            var bmw = new Car();
            var audi = new Car();
            var benz = new Car();
            var parkingLot1 = new ParkingLot(1, 2);
            var parkingLot2 = new ParkingLot(2, 3);
            var smartBoy = new SmartParkingBoy(parkingLot1, parkingLot2);

            parkingLot1.Park(bmw);
            parkingLot2.Park(audi);

            var parkingInfo = smartBoy.Park(benz);

            Assert.Same(benz, parkingLot2.Pick(parkingInfo.ParkingToken));
        }
    }
}
