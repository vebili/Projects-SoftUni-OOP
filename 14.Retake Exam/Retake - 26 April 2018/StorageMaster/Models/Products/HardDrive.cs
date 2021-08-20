namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double ActualWeight = 1.0;
        public HardDrive(double price) 
            : base(price, ActualWeight)
        {
        }
    }
}