namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            storageMaster = new StorageMaster();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }

                StringBuilder result = new StringBuilder();

                string command = input[0];

                try
                {
                    result.AppendLine(ReadCommands(command, input));
                }
                catch (Exception e)
                {
                    result.AppendLine("Error: " + e.Message);
                }

                if (result != null)
                {
                    Console.WriteLine(result.ToString().TrimEnd());
                }
            }

            Console.WriteLine(storageMaster.GetSummary());
        }

        private string ReadCommands(string command, string[] input)
        {
            switch (command)
            {
                case "AddProduct":
                    {
                        string type = input[1];
                        double price = double.Parse(input[2]);

                        return storageMaster.AddProduct(type, price);
                    }

                case "RegisterStorage":
                    {
                        string type = input[1];
                        string name = input[2];

                        return storageMaster.RegisterStorage(type, name);
                    }

                case "SelectVehicle":
                    {
                        string storageName = input[1];
                        int garageSlot = int.Parse(input[2]);

                        return storageMaster.SelectVehicle(storageName, garageSlot);
                    }

                case "LoadVehicle":
                    {
                        List<string> products = input.Skip(1).ToList();

                        return storageMaster.LoadVehicle(products);
                    }

                case "SendVehicleTo":
                    {
                        string sourceName = input[1];
                        int garageSlot = int.Parse(input[2]);
                        string destinationName = input[3];

                        return storageMaster.SendVehicleTo(sourceName, garageSlot, destinationName);
                    }

                case "UnloadVehicle":
                    {
                        string storageName = input[1];
                        int garageSlot = int.Parse(input[2]);

                        return storageMaster.UnloadVehicle(storageName, garageSlot);
                    }

                case "GetStorageStatus":
                    {
                        string storageName = input[1];

                        return storageMaster.GetStorageStatus(storageName);
                    }

                default:
                    return null;
            }
        }
    }
}