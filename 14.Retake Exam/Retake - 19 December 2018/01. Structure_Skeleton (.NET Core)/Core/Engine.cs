namespace SoftUniRestaurant.Core
{
    using System;
    using System.Text;

    public class Engine
    {
        RestaurantController controller;

        public Engine()
        {
            this.controller = new RestaurantController();
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                StringBuilder result = new StringBuilder();

                try
                {
                    ReadCommands(input, result);
                }
                catch (ArgumentException ae)
                {
                    result.AppendLine(ae.Message);
                }

                Console.WriteLine(result.ToString().TrimEnd());
            }

            Console.WriteLine(controller.GetSummary());
        }

        private void ReadCommands(string input, StringBuilder result)
        {
            string[] inputLine = input.Split();
            string command = inputLine[0];

            switch (command)
            {
                case "AddFood":
                    {
                        string type = inputLine[1];
                        string name = inputLine[2];
                        decimal price = decimal.Parse(inputLine[3]);

                        result.AppendLine(controller.AddFood(type, name, price));
                    }
                    break;

                case "AddDrink":
                    {
                        string type = inputLine[1];
                        string name = inputLine[2];
                        int servingSize = int.Parse(inputLine[3]);
                        string brand = inputLine[4];

                        result.AppendLine(controller.AddDrink(type, name, servingSize, brand));
                    }
                    break;

                case "AddTable":
                    {
                        string type = inputLine[1];
                        int tableNumber = int.Parse(inputLine[2]);
                        int capacity = int.Parse(inputLine[3]);

                        result.AppendLine(controller.AddTable(type, tableNumber, capacity));
                    }
                    break;

                case "ReserveTable":
                    {
                        int numberOfPeople = int.Parse(inputLine[1]);

                        result.AppendLine(controller.ReserveTable(numberOfPeople));
                    }
                    break;

                case "OrderFood":
                    {
                        int tableNumber = int.Parse(inputLine[1]);
                        string foodName = inputLine[2];

                        result.AppendLine(controller.OrderFood(tableNumber, foodName));
                    }
                    break;

                case "OrderDrink":
                    {
                        int tableNumber = int.Parse(inputLine[1]);
                        string drinkName = inputLine[2];
                        string drinkBrand = inputLine[3];

                        result.AppendLine(controller.OrderDrink(tableNumber, drinkName, drinkBrand));
                    }
                    break;

                case "LeaveTable":
                    {
                        int tableNumber = int.Parse(inputLine[1]);

                        result.AppendLine(controller.LeaveTable(tableNumber));
                    }
                    break;

                case "GetFreeTablesInfo":
                {
                    result.AppendLine(this.controller.GetFreeTablesInfo());
                }
                    break;

                case "GetOccupiedTablesInfo":
                {
                    result.AppendLine(this.controller.GetOccupiedTablesInfo());
                }
                    break;

                default: break;
            }
        }
    }
}