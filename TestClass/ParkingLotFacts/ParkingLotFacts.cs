using System;
using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCamp.ParkingLotFacts
{
    public class ParkingLotFacts
    {
        [Fact]
        public void should_get_a_car_after_park_a_car()
        {
            var mycar = new Car();
            var parkingLot = new ParkingLot.ParkingLot();

            var parkingInfo = parkingLot.Park(mycar);

            var car = parkingLot.PickCar(parkingInfo.ParkingToken);

            Assert.Same(mycar, car);
        }

        [Fact]
        public void should_not_get_a_car_if_no_car_parked()
        {
            var parkingLot = new ParkingLot.ParkingLot();
            var car = parkingLot.PickCar(Guid.NewGuid());
            Assert.Null(car);
        }

        [Fact]
        public void should_not_get_a_car_if_wrong_token_provided()
        {
            var mycar = new Car();
            var parkingLot = new ParkingLot.ParkingLot();
            parkingLot.Park(mycar);
            var car = parkingLot.PickCar(Guid.NewGuid());
            Assert.Null(car);
        }

        [Fact]
        public void should_not_get_wrong_car_if_multiple_car_parked()
        {
            var mycar = new Car();
            var anotherCar = new Car();
            var parkingLot = new ParkingLot.ParkingLot();
            var token1 = parkingLot.Park(mycar);
            var token2 = parkingLot.Park(anotherCar);
            var car = parkingLot.PickCar(token1.ParkingToken);
            Assert.Same(mycar, car);
            car = parkingLot.PickCar(token2.ParkingToken);
            Assert.Same(anotherCar, car);
        }

        [Fact]
        public void should_return_car_already_parked_when_park_a_existed_car()
        {
            var mycar = new Car();
            var parkingLot = new ParkingLot.ParkingLot();
            parkingLot.Park(mycar);
            var parkingInfo = parkingLot.Park(mycar);
            Assert.Equal(StatusCode.CarAlreadyParked, parkingInfo.StatusCode);
        }

        [Fact]
        public void should_not_get_the_car_if_already_picked()
        {
            var mycar = new Car();
            var parkingLot = new ParkingLot.ParkingLot();
            var parkingInfo = parkingLot.Park(mycar);

            var car = parkingLot.PickCar(parkingInfo.ParkingToken);
            Assert.Equal(mycar, car);
            car = parkingLot.PickCar(parkingInfo.ParkingToken);
            Assert.Null(car);
        }

        [Fact]
        public void should_park_failed_if_parking_lot_full()
        {
            var audi = new Car();
            var parkingLot = new ParkingLot.ParkingLot(1);
            parkingLot.Park(audi);

            var bmw = new Car();
            var parkingInfo = parkingLot.Park(bmw);
            Assert.Equal(StatusCode.ParkinglotIsFull, parkingInfo.StatusCode);
        }
    }
}
