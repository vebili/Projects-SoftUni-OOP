namespace AnimalCentre.Core.Entities
{
    using System;
    using System.Text;
    using Contracts;

    public class Engine : IEngine
    {
        private IAnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                StringBuilder result = new StringBuilder();

                try
                {
                    ReadCommands(input, result);
                }
                catch (InvalidOperationException ioe)
                {
                    result.AppendLine("InvalidOperationException: " + ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    result.AppendLine("ArgumentException: " + ae.Message);
                }



                Console.WriteLine(result.ToString().TrimEnd());
            }

            Console.WriteLine(animalCentre.OwnerAdoptedAnimals());
        }

        private void ReadCommands(string input, StringBuilder result)
        {
            string[] inputLine = input.Split();
            string command = inputLine[0];

            switch (command)
            {
                case "RegisterAnimal":
                    {
                        string type = inputLine[1];
                        string name = inputLine[2];
                        int energy = int.Parse(inputLine[3]);
                        int happiness = int.Parse(inputLine[4]);
                        int procedureTime = int.Parse(inputLine[5]);

                        result.AppendLine(animalCentre.RegisterAnimal(type, name, energy, happiness,
                            procedureTime));
                    }
                    break;

                case "Chip":
                    {
                        string name = inputLine[1];
                        int procedureTime = int.Parse(inputLine[2]);

                        result.AppendLine(animalCentre.Chip(name, procedureTime));
                    }
                    break;

                case "Play":
                    {
                        string name = inputLine[1];
                        int procedureTime = int.Parse(inputLine[2]);

                        result.AppendLine(animalCentre.Play(name, procedureTime));
                    }
                    break;

                case "Fitness":
                    {
                        string name = inputLine[1];
                        int procedureTime = int.Parse(inputLine[2]);

                        result.AppendLine(animalCentre.Fitness(name, procedureTime));
                    }
                    break;

                case "NailTrim":
                    {
                        string name = inputLine[1];
                        int procedureTime = int.Parse(inputLine[2]);

                        result.AppendLine(animalCentre.NailTrim(name, procedureTime));
                    }
                    break;

                case "Vaccinate":
                    {
                        string name = inputLine[1];
                        int procedureTime = int.Parse(inputLine[2]);

                        result.AppendLine(animalCentre.Vaccinate(name, procedureTime));
                    }
                    break;

                case "DentalCare":
                    {
                        string name = inputLine[1];
                        int procedureTime = int.Parse(inputLine[2]);

                        result.AppendLine(animalCentre.DentalCare(name, procedureTime));
                    }
                    break;

                case "Adopt":
                    {
                        string animalName = inputLine[1];
                        string owner = inputLine[2];

                        result.AppendLine(animalCentre.Adopt(animalName, owner));
                    }
                    break;

                case "History":
                    {
                        string name = inputLine[1];

                        result.AppendLine(animalCentre.History(name));
                    }
                    break;

                default: break;
            }
        }
    }
}