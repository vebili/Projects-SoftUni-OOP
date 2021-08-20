namespace StorageMaster.Models.Storages
{

    using Vehicles;

    public class DistributionCenter : Storage
    {
        private const int StorageCapacity = 2;
        private const int StorageGarageSlots = 5;
            
        public DistributionCenter(string name) 
            : base(name, StorageCapacity, StorageGarageSlots, new Vehicle[]{ new Van(), new Van(), new Van() })
        {
        }
    }
}