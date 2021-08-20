namespace _1.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumtion)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtion;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption { get; }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }

        public bool CanDrive(double distance)
        {
            bool canDrive = this.FuelQuantity - this.FuelConsumption * distance >= 0;
            if (!canDrive )
            {
                return false;
            }

            this.FuelQuantity -= FuelConsumption * distance;
            return true;
        }
    }
}
