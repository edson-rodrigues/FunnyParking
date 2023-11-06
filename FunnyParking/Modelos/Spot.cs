namespace FunnyParking.Modelos
{
    public class Spot
    {
        public Vehicle? ParkedVehicle { get; set; }

        public bool IsEmpty()
        {
            return ParkedVehicle == null;
        }
    }
}
