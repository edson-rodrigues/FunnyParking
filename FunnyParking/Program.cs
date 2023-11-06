using FunnyParking.Enums;
using FunnyParking.Modelos;

int numberOfMotorcycleLots, numberOfCarLots, numberofVanLots, option = -1;

Console.WriteLine("....::::::: Parking Lot Management System::::::::.....\n\n");
Console.WriteLine("To start, insert the number of spots of each type in you parking lot:\n");
while (true)
{
    Console.WriteLine("Please, Type the number of Motorcycle spots:");
    string userInput = Console.ReadLine();
    if (int.TryParse(userInput, out numberOfMotorcycleLots))
    {
        break;
    }
    else { Console.WriteLine("Invalid input. Please enter a valid number"); };
}
while (true)
{
    Console.WriteLine("Now, type the number of Car spots:");
    string userInput = Console.ReadLine();
    if (int.TryParse(userInput, out numberOfCarLots))
    {
        break;
    }
    else { Console.WriteLine("Invalid input. Please enter a valid number"); };
}
while (true)
{
    Console.WriteLine(("Finally, type the number of Van (big vehicles) spots:"));
    string userInput = Console.ReadLine();
    if (int.TryParse(userInput, out numberofVanLots))
    {
        break;
    }
    else { Console.WriteLine("Invalid input. Please enter a valid number"); };
}
ParkingLot parkingLot = new ParkingLot(numberOfCarLots, numberOfMotorcycleLots, numberofVanLots);
parkingLot.InitializeSpots();
Console.Clear();
while (option != 0)
{
    while (true)
    { 
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("\n1 - Park a vehicle\n2 - Unpark a vehicle\n3 - See how many availabe spots of each type\n4 - See the total spots generally\n5 - End the program");
        string userInput = Console.ReadLine();
        if(int.TryParse(userInput, out option))
        {
            break;
        }
        else { Console.WriteLine("Invalid input. Please enter a valid number");};
    }
    switch (option){
        case 1: //PARK A VEHICLE
            int vehicleType;
            string licensePlate;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Please, inform the type of the vehicle you would like to park");
                Console.WriteLine("\n1 - Motorcycle\n2 - Car\n3 - Van");
                string userInput = Console.ReadLine();
                if(int.TryParse(userInput , out vehicleType))
                {
                    break;
                }
                else { Console.WriteLine("Invalid input. Please enter a valid number");}
            }
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
        case 2://UNPARK A VEHICLE
            Console.WriteLine("Informe a placa do veiculo estacionado:");
            licensePlate = Console.ReadLine();
            parkingLot.UnParkVehicle(licensePlate);
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
        case 3://GET AVAILABLE SPOTS
            Console.WriteLine($"There are {parkingLot.EmptyMotorcycleSpots()} motorcycle empty spots");
            Console.WriteLine($"There are {parkingLot.EmptyCarSpots()} car empty spots");
            Console.WriteLine($"There are {parkingLot.EmptyVanSpots()} van empty spots");
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
        case 4://GET TOTAL SPOTS
            Console.WriteLine($"There are a total of {parkingLot.TotalCarSpots() + parkingLot.TotalMotorcycleSpots() + parkingLot.TotalVanSpots()} spots in this parking lot.");
            Console.WriteLine("Hit enter to continue");
            Console.ReadLine();
            Console.Clear();
            continue;
        case 5://EXIT PROGRAM
            Console.WriteLine("Thank's for choosing us!");
            break;
        default:
            Console.WriteLine("Invalid option, try again!");
            continue;
    } 
    option = 0;
}

