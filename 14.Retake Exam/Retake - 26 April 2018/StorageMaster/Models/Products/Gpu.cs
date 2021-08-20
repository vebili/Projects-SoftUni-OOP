namespace StorageMaster.Models.Products
{
    public class Gpu : Product
    {
        private const double ActualWeight = 0.7;
        public Gpu(double price) 
            : base(price, ActualWeight)
        {
        }
    }
}