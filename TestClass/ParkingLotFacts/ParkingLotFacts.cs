using System;
using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.ParkingLotFacts
{
    public class ParkingLotFacts
    {
        [Fact]
        public void should_get_a_car_after_park_a_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();

            var parkingInfo = parkingLot.Park(car);

            Assert.Same(car, parkingLot.Pick(parkingInfo.ParkingToken));
        }

        [Fact]
        public void should_pick_car_failed_if_no_car_parked()
        {
            var parkingLot = new ParkingLot();

            var car = parkingLot.Pick(Guid.NewGuid());

            Assert.Null(car);
        }

        [Fact]
        public void should_pick_car_failed_if_wrong_token_provided()
        {
            var mycar = new Car();
            var parkingLot = new ParkingLot();
            parkingLot.Park(mycar);
            var car = parkingLot.Pick(Guid.NewGuid());
            Assert.Null(car);
        }

        [Fact]
        public void should_get_car_correctly_if_multiple_car_parked()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkingLot = new ParkingLot();

            var bmwToken = parkingLot.Park(bmw);
            var audiToken = parkingLot.Park(audi);
            
            Assert.Same(bmw, parkingLot.Pick(bmwToken.ParkingToken));
            Assert.Same(audi, parkingLot.Pick(audiToken.ParkingToken));
        }

        [Fact]
        public void should_not_pick_the_same_car_twice()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();
            var parkingInfo = parkingLot.Park(car);
            
            Assert.Equal(car, parkingLot.Pick(parkingInfo.ParkingToken));
            Assert.Null(parkingLot.Pick(parkingInfo.ParkingToken));
        }

        [Fact]
        public void should_park_failed_if_parking_lot_full()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkingLot = new ParkingLot(1);

            parkingLot.Park(bmw);

            var parkingInfo = parkingLot.Park(audi);
            Assert.Equal(StatusCode.ParkinglotIsFull, parkingInfo.StatusCode);
        }
    }
}
