using System;
using OOBootCamp.ParkingLot;
using Xunit;

namespace TestClass.ParkingBoyFacts
{
    public class ParkingBoyFacts
    {
        [Fact]
        public void should_pick_car_success_after_park_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy();
            var parkingManager = new ParkingLotManager();
            parkingManager.AddParkingLot(parkingLot);
            parkingBoy.ParkingLotManager = parkingManager;

            var parkingInfo = parkingBoy.Park(car);
            Assert.Same(car, parkingBoy.PickCar(parkingInfo));
        }

        [Fact]
        public void should_park_car_to_first_parkingLot_if_it_is_not_full()
        {
            var bmw = new Car();
            var audi = new Car();
            var parkingLot = new ParkingLot(2);

            var parkingManager = new ParkingLotManager();
            parkingManager.AddParkingLot(parkingLot);
            parkingManager.AddParkingLot(new ParkingLot(2));
            var parkingBoy = new ParkingBoy {ParkingLotManager = parkingManager};

            var bmwParkingInfo = parkingBoy.Park(bmw);
            var audiParkingInfo = parkingBoy.Park(audi);

            Assert.Equal(parkingLot.ParkingLotNumber, bmwParkingInfo.ParkingLotNumber);
            Assert.Equal(parkingLot.ParkingLotNumber, audiParkingInfo.ParkingLotNumber);
        }

        [Fact]
        public void should_park_car_to_second_parkingLot_if_the_first_parkingLot_is_full()
        {
            var bmw = new Car();
            var audi = new Car();

            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);

            var parkingManager = new ParkingLotManager();
            parkingManager.AddParkingLot(parkingLot1);
            parkingManager.AddParkingLot(parkingLot2);
            var parkingBoy = new ParkingBoy {ParkingLotManager = parkingManager};

            var bmwParkingInfo = parkingBoy.Park(bmw);
            var audiParkingInfo = parkingBoy.Park(audi);

            Assert.Equal(parkingLot1.ParkingLotNumber, bmwParkingInfo.ParkingLotNumber);
            Assert.Equal(parkingLot2.ParkingLotNumber, audiParkingInfo.ParkingLotNumber);
        }

        [Fact]
        public void should_park_car_to_first_available_parkingLot_if_there_are_mutiple_available_parkingLots()
        {
            var bmw = new Car();
            var audi = new Car();
            var changcheng = new Car();

            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(1);

            var parkingManager = new ParkingLotManager();
            parkingManager.AddParkingLot(parkingLot1);
            parkingManager.AddParkingLot(parkingLot2);
            parkingManager.AddParkingLot(new ParkingLot(1));
            var parkingBoy = new ParkingBoy {ParkingLotManager = parkingManager};

            var bmwToken = parkingBoy.Park(bmw);
            parkingBoy.Park(audi);
            parkingBoy.PickCar(bmwToken);

            var changchengparkingInfo = parkingBoy.Park(changcheng);
            Assert.Equal(parkingLot1.ParkingLotNumber, changchengparkingInfo.ParkingLotNumber);
        }

        [Fact]
        public void should_park_car_fail_when_all_parkingLots_are_full()
        {
            var parkingLotManager = new ParkingLotManager();
            parkingLotManager.AddParkingLot(new ParkingLot(1));
            var parkingBoy = new ParkingBoy {ParkingLotManager = parkingLotManager};
            parkingBoy.Park(new Car());

            Assert.Throws<InvalidOperationException>(() => parkingBoy.Park(new Car()));
        }
    }
}