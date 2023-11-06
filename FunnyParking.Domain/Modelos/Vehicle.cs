using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyParking.Domain.Modelos
{
    public class Vehicle
    {
        public string  LicensePlate { get; set; }
        public Vehicle(string licensePlate)
        {
            LicensePlate = licensePlate;
        }
    }
}
