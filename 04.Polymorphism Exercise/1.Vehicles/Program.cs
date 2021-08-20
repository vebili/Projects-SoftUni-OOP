using System;

namespace _1.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split();
            string[] truckTokens = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));
            Vehicle truck = new Truck( double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

            int numberOfComments = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfComments; i++)
            {
                string[] currentLine = Console.ReadLine().Split();
                string command = currentLine[0];
                string type = currentLine[1];
                double amount = double.Parse(currentLine[2]);

                if (command == "Drive")
                {
                    if (type == "Car")
                    {
                        CanDrive(car, amount);
                    }
                    else
                    {
                        CanDrive(truck, amount);
                    }
                }
                else
                {
                    if (type == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }

        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string vehicleType = vehicle.GetType().Name;
            string result = canDrive
                ? $"{vehicleType} travelled {distance} km"
                : $"{vehicleType} needs refueling";

            Console.WriteLine(result);
        }
    }
}
