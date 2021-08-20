namespace _1.Vehicles
{
    public class Car:Vehicle
    {
        private const double AirConditionConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumtion) 
            : base(fuelQuantity, fuelConsumtion)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + AirConditionConsumption;
    }
}
