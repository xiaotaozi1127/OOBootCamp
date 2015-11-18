using System;
using System.Collections.Generic;
using System.Linq;
using OOBootCamp.ParkingLot;

namespace OOBootCamp.ParkingBoy
{
    public class ParkingBoy
    {
        List<ParkingLot.ParkingLot> parkingLotList;

        public ParkingBoy()
        {
            parkingLotList = new List<ParkingLot.ParkingLot>();
        }

        public ParkingInfo Park(Car car)
        {
            var availableParkingLot = GetAvailableParkingLot();
            var token = availableParkingLot.Park(car);
            return new ParkingInfo() {ParkingLotNumber = availableParkingLot.ParkingLotNumber, ParkingToken = token};
        }

        public Car PickCar(ParkingInfo parkingInfo)
        {
            var parkingLot = parkingLotList.Single(t => t.ParkingLotNumber == parkingInfo.ParkingLotNumber);
            return parkingLot.PickCar(parkingInfo.ParkingToken);
        }

        public class ParkingInfo
        {
            public int ParkingLotNumber { get; set; }
            public Guid ParkingToken { get; set; }
        }

        public void AddParkingLot(ParkingLot.ParkingLot parkingLot)
        {
            parkingLotList.Add(parkingLot);
            parkingLot.ParkingLotNumber = parkingLotList.Count;
        }

        public ParkingLot.ParkingLot GetAvailableParkingLot()
        {
            return parkingLotList.FirstOrDefault(parkingLot => parkingLot.NotFull());
        }
    }
}
