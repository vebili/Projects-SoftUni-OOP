namespace StorageMaster.Core.Factories
{
    using System;
    using Models.Products;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product product = null;

            if (type == "Gpu")
            {
                product = new Gpu(price);
            }
            else if (type == "HardDrive")
            {
                product = new HardDrive(price);
            }
            else if (type == "Ram")
            {
                product = new Ram(price);
            }
            else if (type == "SolidStateDrive")
            {
                product = new SolidStateDrive(price);
            }
            else
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            return product;
        }
    }
}