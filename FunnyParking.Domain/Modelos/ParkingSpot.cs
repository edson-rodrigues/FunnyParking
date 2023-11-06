using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyParking.Domain.Modelos
{
    public class ParkingSpot
    {
        public Vehicle ParkedVehicle { get; set; }

        public bool IsEmpty()
        {
            return ParkedVehicle == null;
        }
    }
}
