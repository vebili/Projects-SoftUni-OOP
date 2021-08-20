namespace _2.Vehicles_Extension
{
    public class Bus : Vehicle
    {
        private const double AirConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumtion, double tankCapacity) : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public bool isEmpty { get; set; }

        public override double FuelConsumption => this.isEmpty
            ? base.FuelConsumption
            : base.FuelConsumption + AirConditionConsumption;
    }
}
