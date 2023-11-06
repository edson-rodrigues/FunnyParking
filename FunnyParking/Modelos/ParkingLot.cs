using FunnyParking.Enums;

namespace FunnyParking.Modelos
{
    public class ParkingLot
    {
        public List<CarSpot> CarSpots { get; set; }
        public List<MotorcycleSpot> MotorcycleSpots { get; set; }
        public List<VanSpot> VanSpots { get; set; }

        public ParkingLot(int NcarSpots, int NmotorcycleSpots, int NvanSpots)
        {
            CarSpots = new List<CarSpot>(NcarSpots);
            MotorcycleSpots = new List<MotorcycleSpot>(NmotorcycleSpots);
            VanSpots = new List<VanSpot>(NvanSpots);
        }

        public void InitializeSpots()
        {
            for (int i = 0; i < CarSpots.Capacity; i++)
            {
                CarSpots.Add(new CarSpot());
            }
            for(int i = 0;i < MotorcycleSpots.Capacity; i++)
            {
                MotorcycleSpots.Add(new MotorcycleSpot());
            }
            for(int i = 0;i< VanSpots.Capacity; i++)
            {
                VanSpots.Add(new VanSpot());
            }
        }

        public int EmptyCarSpots()
        {
            return CarSpots.Count(spot => spot.IsEmpty());
        }

        public int EmptyMotorcycleSpots()
        {
            return MotorcycleSpots.Count(spot => spot.IsEmpty());
        }

        public int EmptyVanSpots()
        {
            return VanSpots.Count(spot => spot.IsEmpty()) ;
        }

        public int TotalMotorcycleSpots()
        {
            return MotorcycleSpots.Count;
        }

        public int TotalCarSpots()
        {
            return CarSpots.Count;
        }

        public int TotalVanSpots()
        {
            return VanSpots.Count;
        }

        public bool IsFull()
        {
            return EmptyMotorcycleSpots() == 0 && EmptyCarSpots() == 0 && EmptyVanSpots() == 0;
        }

        public bool IsEmpty()
        {
            return EmptyMotorcycleSpots() == MotorcycleSpots.Count && EmptyCarSpots() == CarSpots.Count && EmptyVanSpots() == VanSpots.Count;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            if (vehicle.VehicleType == VehicleType.CAR)
            {
                Spot spot = CarSpots.Find(s => s.IsEmpty());
                if(spot == null)
                {
                    spot = VanSpots.Find(s => s.IsEmpty()) ;
                }
                if (spot != null)
                {
                    spot.ParkedVehicle = vehicle;
                    Console.WriteLine("Vehicle Parked");
                }
                else
                {
                    Console.WriteLine("No compatible parking spots available");
                }
            }
            else if(vehicle.VehicleType == VehicleType.VAN)
            {
                Spot spot = VanSpots.Find(s => s.IsEmpty());
                if(spot == null)
                {
                    for (int i = 0; i < CarSpots.Count - 2; i++)
                    {
                        if (CarSpots[i].IsEmpty() && CarSpots[i+1].IsEmpty() && CarSpots[i + 2].IsEmpty())
                        {
                            CarSpots[i].ParkedVehicle = vehicle;
                            CarSpots[i + 1].ParkedVehicle = vehicle;
                            CarSpots[i + 2].ParkedVehicle = vehicle;
                            Console.WriteLine("Vehicle Parked");
                            break;
                        }
                    }
                }
                else if(spot != null)
                {
                    spot.ParkedVehicle = vehicle;
                    Console.WriteLine("Vehicle Parked");
                }
                else
                {
                    Console.WriteLine("No compatible parking spots available");
                }
            }

            else if(vehicle.VehicleType == VehicleType.MOTORCYCLE)
            {
                Spot spot = MotorcycleSpots.Find(s => s.IsEmpty());
                if(spot == null)
                {
                    spot = CarSpots.Find(s => s.IsEmpty());
                    if(spot == null)
                    {
                        spot = VanSpots.Find(s => s.IsEmpty());
                    }
                }
                if(spot != null)
                {
                    spot.ParkedVehicle = vehicle;
                    Console.WriteLine("Vehicle Parked");
                }
                else
                {
                    Console.WriteLine("Parking Lot Is Full");
                }

            }
        }

        public void UnParkVehicle(string licensePlate)
        {
            List<CarSpot>? CarSpotsToFree = CarSpots.FindAll(s => s.ParkedVehicle?.LicensePlate == licensePlate);
            List<MotorcycleSpot>? MotorcycleSpotsToFree = MotorcycleSpots.FindAll(s => s.ParkedVehicle?.LicensePlate == licensePlate);
            List<VanSpot>? VanSpotsToFree = VanSpots.FindAll(s => s.ParkedVehicle?.LicensePlate == licensePlate);

            if(CarSpotsToFree == null &&  MotorcycleSpotsToFree == null & VanSpotsToFree == null)
            {
                Console.WriteLine("No vehicle with the given License Plate parked here");    
            }
            if(MotorcycleSpotsToFree.Count > 0)
            {
                MotorcycleSpot spot = MotorcycleSpots.FirstOrDefault(s => s.ParkedVehicle?.LicensePlate == licensePlate);
                spot.ParkedVehicle = null;
                Console.WriteLine("Vehicle unparked sucessfully");
            }
            if(CarSpotsToFree.Count > 0)
            {
                for(int i = 0; CarSpots.Count > i; i++)
                {
                    if (CarSpots[i].ParkedVehicle?.LicensePlate == licensePlate)
                    {
                        CarSpots[i].ParkedVehicle = null;
                    }
                }
                Console.WriteLine("Vehicle unparked sucessfully");
            }
            if(VanSpotsToFree.Count > 0)
            {
                VanSpot spot = VanSpots.FirstOrDefault(s => s.ParkedVehicle?.LicensePlate == licensePlate);
                spot.ParkedVehicle = null;
                Console.WriteLine("Vehicle unparked sucessfully");
            }
        }
    }
}
