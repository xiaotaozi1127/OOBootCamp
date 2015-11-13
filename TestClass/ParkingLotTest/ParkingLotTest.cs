using System;
using OOSession.ParkingLot;
using Xunit;

namespace TestClass.ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void should_get_a_car_after_park_a_car()
        {
            var mycar = new Car("no1");
            var parkingLot = new ParkingLot();
            var token = parkingLot.Park(mycar);
            var car = parkingLot.GetCar(token);
            Assert.NotNull(car);
        }

        [Fact]
        public void should_not_get_a_car_if_no_car_parked()
        {
            var parkingLot = new ParkingLot();
            var car = parkingLot.GetCar(Guid.NewGuid());
            Assert.Null(car);
        }

        [Fact]
        public void should_not_get_a_car_if_wrong_token_provided()
        {
            var mycar = new Car("no1");
            var parkingLot = new ParkingLot();
            parkingLot.Park(mycar);
            var car = parkingLot.GetCar(Guid.NewGuid());
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
            var car = parkingLot.GetCar(token1);
            Assert.Equal(mycar, car);
            car = parkingLot.GetCar(token2);
            Assert.NotEqual(mycar, car);
        }
    }
}
