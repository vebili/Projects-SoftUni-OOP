namespace StorageMaster.Models.Storages
{

    using Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int StorageCapacity = 1;
        private const int StorageGarageSlots = 2;
            
        public AutomatedWarehouse(string name) 
            : base(name, StorageCapacity, StorageGarageSlots, new Vehicle[]{ new Truck() })
        {
        }
    }
}