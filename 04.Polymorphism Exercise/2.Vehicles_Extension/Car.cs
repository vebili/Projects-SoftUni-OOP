namespace _2.Vehicles_Extension
{
    public class Car : Vehicle
    {
        private const double AirConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumtion, double tankCapacity)
            : base(fuelQuantity, fuelConsumtion, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + AirConditionConsumption;
    }
}
