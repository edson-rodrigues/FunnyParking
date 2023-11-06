using FunnyParking.Enums;
using FunnyParking.Modelos;

int numberOfMotorcycleLots, numberOfCarLots, numberofVanLots, option = -1;

Console.WriteLine("Parking Lot Management System");
Console.WriteLine("To start, insert the number of lots of each type in you parking lot:");
Console.WriteLine("Type the number of Motorcyle lots:");
numberOfMotorcycleLots = Int32.Parse(Console.ReadLine());
Console.WriteLine("Now, type the number of Car lots:");
numberOfCarLots = Int32.Parse(Console.ReadLine());
Console.WriteLine(("Finally, type the number of Van (big vehicles) lots:"));
numberofVanLots = Int32.Parse(Console.ReadLine());

ParkingLot parkingLot = new ParkingLot(numberOfCarLots, numberOfMotorcycleLots, numberofVanLots);
parkingLot.InitializeSpots();
Console.Clear();
while (option != 0)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("\n1 - Park a vehicle\n2 - Unpark a vehicle\n3 - See how many availabe spots of each type\n4 - See the total spots generally\n5 - End the program");
    option = Int32.Parse(Console.ReadLine());
    switch (option){
        case 1: //PARK A VEHICLE
            int vehicleType;
            string licensePlate;
            Console.Clear();
            Console.WriteLine("Please, inform the type of the vehicle you would like to park");
            Console.WriteLine("\n1 - Motorcycle\n2 - Car\n3 - Van");
            vehicleType = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Now, inform the vehicle license plate:");
            licensePlate = Console.ReadLine();
            switch (vehicleType)
            {   
                case 1:
                    Vehicle motorcycle = new Vehicle(VehicleType.MOTORCYCLE, licensePlate);
                    parkingLot.ParkVehicle(motorcycle);
                    Console.WriteLine("Hit enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 2:
                    Vehicle car = new Vehicle(VehicleType.CAR, licensePlate);
                    parkingLot.ParkVehicle(car);
                    Console.WriteLine("Hit enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 3:
                    Vehicle van = new Vehicle(VehicleType.VAN, licensePlate);
                    parkingLot.ParkVehicle(van);
                    Console.WriteLine("Hit enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                default:
                    Console.WriteLine("Invalid option");
                    continue;
            }
        case 2:
            Console.WriteLine("Informe a placa do veiculo estacionado:");
            licensePlate = Console.ReadLine();
            parkingLot.UnParkVehicle(licensePlate);
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
        case 3:
            Console.WriteLine($"There are {parkingLot.EmptyMotorcycleSpots()} motorcycle empty spots");
            Console.WriteLine($"There are {parkingLot.EmptyCarSpots()} car empty spots");
            Console.WriteLine($"There are {parkingLot.EmptyVanSpots()} van empty spots");
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
        case 4:
            Console.WriteLine($"There are a total of {parkingLot.TotalCarSpots() + parkingLot.TotalMotorcycleSpots() + parkingLot.TotalVanSpots()} spots in this parking lot.");
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
        case 5:
            Console.WriteLine("Thank's for choosing us!");
            break;
    } 
    option = 0;
}

