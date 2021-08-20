namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        private const int ConstantCapacity = 10;
        public Semi() 
            : base(ConstantCapacity)
        {
        }
    }
}