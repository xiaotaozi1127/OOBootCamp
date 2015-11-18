using OOBootCamp.ParkingLot;
using Xunit;

namespace TestClass.ParkingBoyFacts
{
    public class ParkingBoyFacts
    {
        [Fact]
        public void should_pick_car_after_park_car()
        {
            var car = new Car("no1");
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy();
            var parkingManager = new ParkingLotManager();
            parkingManager.AddParkingLot(parkingLot);
            parkingBoy.ParkingLotManager = parkingManager;

            var parkingInfo = parkingBoy.Park(car);
            Assert.Same(car, parkingBoy.PickCar(parkingInfo));
        }

        [Fact]
        public void should_park_to_an_exist_parkingLot_is_not_full()
        {
            var bmw = new Car("no1");
            var audi = new Car("no2");
            var parkingLot = new ParkingLot(2);
            var parkingBoy = new ParkingBoy();

            var parkingManager = new ParkingLotManager();
            parkingManager.AddParkingLot(parkingLot);
            parkingBoy.ParkingLotManager = parkingManager;

            var bmwParkingInfo = parkingBoy.Park(bmw);
            var audiParkingInfo = parkingBoy.Park(audi);

            Assert.True(bmwParkingInfo.ParkingLotNumber == audiParkingInfo.ParkingLotNumber);
        }

        [Fact]
        public void should_park_to_a_new_parkingLot_if_is_full()
        {
            var bmw = new Car("no1");
            var audi = new Car("no2");
            var parkingBoy = new ParkingBoy();

            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);


            var parkingManager = new ParkingLotManager();
            parkingManager.AddParkingLot(parkingLot1);
            parkingManager.AddParkingLot(parkingLot2);
            parkingBoy.ParkingLotManager = parkingManager;

            var bmwParkingInfo = parkingBoy.Park(bmw);
            var audiParkingInfo = parkingBoy.Park(audi);

            Assert.True(bmwParkingInfo.ParkingLotNumber == 1);
            Assert.True(audiParkingInfo.ParkingLotNumber == 2);
            Assert.True(bmwParkingInfo.ParkingLotNumber != audiParkingInfo.ParkingLotNumber);
        }
    }
}
