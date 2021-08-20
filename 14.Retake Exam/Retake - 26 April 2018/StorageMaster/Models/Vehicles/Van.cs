namespace StorageMaster.Models.Vehicles
{
    public class Van : Vehicle
    {
        private const int ConstantCapacity = 2;
        public Van() 
            : base(ConstantCapacity)
        {
        }
    }
}