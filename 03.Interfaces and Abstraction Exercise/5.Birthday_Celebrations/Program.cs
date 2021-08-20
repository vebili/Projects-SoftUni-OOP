using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split();

                string type = parts[0];
                if (type == nameof(Citizen))
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthDate = parts[4];

                    birthables.Add(new Citizen(name, age, id, birthDate));
                }
                else if (type == nameof(Pet))
                {
                    string name = parts[1];
                    string birthDate = parts[2];

                    birthables.Add(new Pet(name, birthDate));
                }
            }

            string filtereYear = Console.ReadLine();

            List<IBirthable> filtered = birthables
                .Where(b => b.BirthDate.EndsWith(filtereYear))
                .ToList();

            foreach (var birthable in filtered)
            {
                Console.WriteLine(birthable.BirthDate);
            }
        }
    }
}