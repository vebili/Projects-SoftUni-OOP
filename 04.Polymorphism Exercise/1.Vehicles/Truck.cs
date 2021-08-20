using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumtion)
            : base(fuelQuantity, fuelConsumtion)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + AirConditionConsumption;

        public override void Refuel(double amount)
        {
            base.Refuel(amount*0.95);
        }
    }
}
