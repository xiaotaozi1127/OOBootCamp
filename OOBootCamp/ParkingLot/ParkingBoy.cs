using System;

namespace OOBootCamp.ParkingLot
{
    public class ParkingBoy
    {
        public ParkingLotManager ParkingLotManager { get; set; }

        public ParkingInfo Park(Car car)
        {
            var availableParkingLot = ParkingLotManager.GetAvailableParkingLot();
            if (availableParkingLot == null) throw new InvalidOperationException("There is no available parking lot");
            var token = availableParkingLot.Park(car);
            return new ParkingInfo(availableParkingLot.ParkingLotNumber, token);
        }

        public Car PickCar(ParkingInfo parkingInfo)
        {
            var parkingLot = ParkingLotManager.GetParkingLotByParkingNumber(parkingInfo.ParkingLotNumber);
            return parkingLot.PickCar(parkingInfo.ParkingToken);
        }
    }
}
