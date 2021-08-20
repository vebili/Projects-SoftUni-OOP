namespace StorageMaster.Models.Storages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Products;
    using Vehicles;

    public abstract class Storage
    {
        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[garageSlots];
            this.products = new List<Product>();

            this.InitializeGarage(vehicles);
        }


        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int freeSlot = deliveryLocation.Garage.ToList().IndexOf(this.garage.FirstOrDefault(s => s == null));

            if (freeSlot < 0)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            
            return ((Storage)deliveryLocation).AddVehicle(vehicle);
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int unloadedProducts = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                this.products.Add(vehicle.Unload());
                unloadedProducts++;
            }

            return unloadedProducts;
        }
        private int AddVehicle(Vehicle vehicle)
        {
            int freeGarageSlotIndex =  Array.IndexOf(this.garage, null);

            this.garage[freeGarageSlotIndex] = vehicle;

            return freeGarageSlotIndex;
        }

        
        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[garageSlot++] = vehicle;
            }
        }
    }
}