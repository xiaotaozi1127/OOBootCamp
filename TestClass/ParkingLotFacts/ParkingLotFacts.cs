using System;
using OOBootCamp.ParkingLot;
using Xunit;

namespace TestClass.ParkingLotFacts
{
    public class ParkingLotFacts
    {
        [Fact]
        public void should_get_a_car_after_park_a_car()
        {
            var mycar = new Car("no1");
            var parkingLot = new ParkingLot();
            var token = parkingLot.Park(mycar);

            var car = parkingLot.PickCar(token);

            Assert.Same(mycar, car);
        }

        [Fact]
        public void should_not_get_a_car_if_no_car_parked()
        {
            var parkingLot = new ParkingLot();
            var car = parkingLot.PickCar(Guid.NewGuid());
            Assert.Null(car);
        }

        [Fact]
        public void should_not_get_a_car_if_wrong_token_provided()
        {
            var mycar = new Car("no1");
            var parkingLot = new ParkingLot();
            parkingLot.Park(mycar);
            var car = parkingLot.PickCar(Guid.NewGuid());
            Assert.Null(car);
        }

        [Fact]
        public void should_not_get_wrong_car_if_multiple_car_parked()
        {
            var mycar = new Car("no1");
            var anotherCar = new Car("no2");
            var parkingLot = new ParkingLot();
            var token1 = parkingLot.Park(mycar);
            var token2 = parkingLot.Park(anotherCar);
            var car = parkingLot.PickCar(token1);
            Assert.Same(mycar, car);
            car = parkingLot.PickCar(token2);
            Assert.Same(anotherCar, car);
        }

        [Fact]
        public void should_throw_exception_when_park_a_existed_car()
        {
            var mycar = new Car("no1");
            var parkingLot = new ParkingLot();
            parkingLot.Park(mycar);

            Assert.Throws<InvalidOperationException>(
                () => parkingLot.Park(mycar));
        }

        [Fact]
        public void should_park_car_again_after_pick_a_car()
        {
            var mycar = new Car("no1");
            var parkingLot = new ParkingLot();
            var token = parkingLot.Park(mycar);
            parkingLot.PickCar(token);

            parkingLot.Park(mycar);
            Assert.NotEqual(Guid.Empty, token);
        }

        [Fact]
        public void should_not_get_the_car_if_already_picked()
        {
            var mycar = new Car("no1");
            var parkingLot = new ParkingLot();
            var token = parkingLot.Park(mycar);

            var car = parkingLot.PickCar(token);
            Assert.Equal(mycar, car);
            car = parkingLot.PickCar(token);
            Assert.Null(car);
        }
    }
}
