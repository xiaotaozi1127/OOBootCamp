using System;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy
    {
        public ParkingLotManager ParkingLotManager { get; set; }

        public ParkingInfo Park(Car car)
        {
            var availableParkingLot = ParkingLotManager.GetAvailableParkingLot();
            var token = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotNumber, token);
        }

        public Car PickCar(ParkingInfo parkingInfo)
        {
            var parkingLot = ParkingLotManager.GetParkingLotByParkingNumber(parkingInfo.ParkingLotNumber);
            return parkingLot.PickCar(parkingInfo.ParkingToken);
        }

        public class ParkingInfo
        {
            public ParkingInfo(int parkingLotNumber, Guid parkingToken)
            {
                ParkingLotNumber = parkingLotNumber;
                ParkingToken = parkingToken;
            }
            public int ParkingLotNumber { get; set; }
            public Guid ParkingToken { get; set; }
        }
    }
}
