namespace StorageMaster.Models.Products
{
    public class SolidStateDrive : Product
    {
        private const double ActualWeight = 0.2;
        public SolidStateDrive(double price) 
            : base(price, ActualWeight)
        {
        }
    }
}