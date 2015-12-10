using System.Collections.Generic;
using OOBootCamp.ParkingLot;
using Xunit;

namespace OOBootCampTest.ParkingDirectorFacts
{
    public class ParkingDirectorFacts
    {
        [Fact]
        public void should_get_park_status_when_no_car_parked()
        {
            var manager = new ParkingBoyManager(new List<IParkable> { new ParkingLot(1) });

            Assert.Equal("M 0 1\r\n  P 0 1", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_when_only_one_parkingLot_parked()
        {
            var manager = new ParkingBoyManager(new List<IParkable> { new ParkingLot(1) });

            manager.Park(new Car());

            Assert.Equal("M 1 1\r\n  P 1 1", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_when_multiple_parkingLots_parked()
        {
            var manager = new ParkingBoyManager(new List<IParkable> { new ParkingLot(1), new ParkingLot(2) });

            manager.Park(new Car());
            manager.Park(new Car());

            Assert.Equal("M 2 3\r\n  P 1 1\r\n  P 1 2", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_when_one_parkingBoy_parked()
        {
            var parkingBoy = new ParkingBoy(new ParkingLot(2));
            var manager = new ParkingBoyManager(new List<IParkable> {new ParkingLot(1), parkingBoy});

            parkingBoy.Park(new Car());

            Assert.Equal("M 1 3\r\n  P 0 1\r\n  B 1 2\r\n    P 1 2", manager.GetParkStatus());
        }

        [Fact]
        public void should_get_park_status_with_multiple_parkingBoy_parked()
        {
            var parkingBoy = new ParkingBoy(new ParkingLot(2), new ParkingLot(3));
            var manager = new ParkingBoyManager(new List<IParkable> { new ParkingLot(1), parkingBoy, new ParkingBoy(new ParkingLot(2)) });

            parkingBoy.Park(new Car());

            Assert.Equal("M 1 8\r\n  P 0 1\r\n  B 1 5\r\n    P 1 2\r\n    P 0 3\r\n  B 0 2\r\n    P 0 2", manager.GetParkStatus());
        }
    }
}
