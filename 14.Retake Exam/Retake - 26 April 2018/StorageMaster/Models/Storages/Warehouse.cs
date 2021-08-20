namespace StorageMaster.Models.Storages
{
    using Vehicles;

    public class Warehouse : Storage
    {
        private const int StorageCapacity = 10;
        private const int StorageGarageSlots = 10;
            
        public Warehouse(string name) 
            : base(name, StorageCapacity, StorageGarageSlots, new Vehicle[]{ new Semi(), new Semi(), new Semi() })
        {
        }
    }
}