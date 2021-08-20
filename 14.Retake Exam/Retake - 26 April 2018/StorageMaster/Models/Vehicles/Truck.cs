namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int ConstantCapacity = 5;
        public Truck() 
            : base(ConstantCapacity)
        {
        }
    }
}