using FunnyParking.Enums;

namespace FunnyParking.Modelos
{
    public class Vehicle
    {
        public VehicleType VehicleType { get; set; }
        public string LicensePlate { get; set; }
        public Vehicle(VehicleType vehicleType, string licensePlate)
        {
            VehicleType = vehicleType;
            LicensePlate = licensePlate;
        }
    }
}
