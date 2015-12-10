using System.Collections.Generic;
using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.ParkingDirectorFacts
{
    public class ParkingDirectorFacts
    {
        [Fact]
        public void should_output_manager_park_status_when_no_car_parked()
        {
            var parkingLot = new ParkingLot(1);
            var manager = new ParkingBoyManager(new List<IParkingBoy> { parkingLot });
            Assert.Equal("M 0 1\r\n  P 0 1", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_with_only_one_parkingLot_parked()
        {
            var parkingLot = new ParkingLot(1);
            var manager = new ParkingBoyManager(new List<IParkingBoy> { parkingLot });
            manager.Park(new Car());
            Assert.Equal("M 1 1\r\n  P 1 1", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_with_multiple_parkingLot_parked()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot(2);
            var manager = new ParkingBoyManager(new List<IParkingBoy> { parkingLot1, parkingLot2 });
            parkingLot1.Park(new Car());
            parkingLot2.Park(new Car());
            Assert.Equal("M 2 3\r\n  P 1 1\r\n  P 1 2", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_with_one_parkingBoy_parked()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new ParkingLot(2));
            var manager = new ParkingBoyManager(new List<IParkingBoy> {parkingLot, parkingBoy});
            parkingBoy.Park(new Car());

            Assert.Equal("M 1 3\r\n  P 0 1\r\n  B 1 2\r\n    P 1 2", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_with_multiple_parkingBoy_parked()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new ParkingLot(2));
            var parkingBoy2 = new ParkingBoy(new ParkingLot(2));
            var manager = new ParkingBoyManager(new List<IParkingBoy> { parkingLot, parkingBoy, parkingBoy2 });
            parkingBoy.Park(new Car());

            Assert.Equal("M 1 5\r\n  P 0 1\r\n  B 1 2\r\n    P 1 2\r\n  B 0 2\r\n    P 0 2", manager.GetParkStatus());
        }
    }
}
