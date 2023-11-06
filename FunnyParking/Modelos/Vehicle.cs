using FunnyParking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
