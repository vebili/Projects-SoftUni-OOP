namespace StorageMaster.Core
{
    using Factories;

    using Models.Products;
    using Models.Vehicles;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models.Storages;

    public class StorageMaster
    {
        private readonly Dictionary<string, Storage> storageRegistry;
        private readonly Dictionary<string, Stack<Product>> productsPool;

        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productsPool = new Dictionary<string, Stack<Product>>();
            this.storageRegistry = new Dictionary<string, Storage>();

            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            if (!this.productsPool.ContainsKey(type))
            {
                this.productsPool[type] = new Stack<Product>();
            }

            Product product = this.productFactory.CreateProduct(type, price);

            this.productsPool[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry[storageName];
            Vehicle vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProducts = 0;

            foreach (var name in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.productsPool.ContainsKey(name) || !this.productsPool[name].Any())
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }

                Product product = this.productsPool[name].Pop();

                this.currentVehicle.LoadProduct(product);

                loadedProducts++;
            }

            int totalProductsCount = productNames.Count();

            return $"Loaded {loadedProducts}/{totalProductsCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = this.storageRegistry[sourceName];
            Storage destinationStorage = this.storageRegistry[destinationName];

            Vehicle sendVehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {sendVehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage currentStorage = this.storageRegistry[storageName];

            Vehicle vehicleToUnload = currentStorage.GetVehicle(garageSlot);

            int productsInVehicle = vehicleToUnload.Trunk.Count;
            int unloadedProductsCount = currentStorage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storageRegistry[storageName];
            
            string[] stockInfo = storage.Products
                            .GroupBy(p => p.GetType().Name)
                            .Select(g => new
                            {
                                Name = g.Key,
                                Count = g.Count()
                            })
                            .OrderByDescending(p => p.Count)
                            .ThenBy(p => p.Name)
                            .Select(p => $"{p.Name} ({p.Count})")
                            .ToArray();

            double productsCapacity = storage.Products.Sum(p => p.Weight);

            string stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                                     productsCapacity,
                                     storage.Capacity,
                                     string.Join(", ", stockInfo));

            List<Vehicle> garage = storage.Garage.ToList();

            string[] vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            string garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));

            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            StringBuilder report = new StringBuilder();

            foreach (var storage in storageRegistry
                .OrderByDescending(s => s.Value.Products.Sum(p => p.Price)))
            {
                string storageName = storage.Key;
                double totalMoney = storage.Value.Products.Sum(p => p.Price);

                report.AppendLine($"{storage.Key}:")
                    .AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return report.ToString().TrimEnd();
        }

    }
}