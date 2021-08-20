namespace StorageMaster.Core.Factories
{
    using Models.Vehicles;

    using System;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;

            if (type == "Semi")
            {
                vehicle = new Semi();
            }
            else if (type == "Van")
            {
                vehicle = new Van();
            }
            else if (type == "Truck")
            {
                vehicle = new Truck();
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}