using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.ParkingBoyFacts
{
    public class ParkingBoyFacts
    {
        [Fact]
        public void parkingLot_should_pick_car_success_after_parkingBoy_park_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);

            var parkingInfo = parkingBoy.Park(car);

            Assert.Same(car, parkingLot.Pick(parkingInfo.ParkingToken));
        }

        [Fact]
        public void parkingBoy_should_pick_car_success_after_parkingBoy_park_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);

            var parkingInfo = parkingBoy.Park(car);

            Assert.Same(car, parkingBoy.Pick(parkingInfo));
        }

        [Fact]
        public void should_park_car_fail_if_all_parkingLots_are_full()
        {
            var parkingBoy = new ParkingBoy(new ParkingLot(1));

            parkingBoy.Park(new Car());

            Assert.Equal(StatusCode.ParkinglotIsFull, parkingBoy.Park(new Car()).StatusCode);
        }

        [Fact]
        public void should_park_to_first_available_parkingLot_for_mutiple_available_parkingLots()
        {
            var bmw = new Car();
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot1, parkingLot2);

            var bmwParkingInfo = parkingBoy.Park(bmw);

            Assert.Same(bmw, parkingLot1.Pick(bmwParkingInfo.ParkingToken));
        }
    }
}