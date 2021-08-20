namespace AnimalCentre.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    using Models.Contracts;
    using Models.Entities.Hotel;
    using Models.Entities.Procedures;

    public class AnimalCentre : IAnimalCentre
    {
        private IHotel hotel;
        private AnimalFactory animalFactory;
        private Dictionary<string, IProcedure> procedures;
        private Dictionary<string, List<string>> ownerAnimals;


        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();
            this.procedures = new Dictionary<string, IProcedure>();
            CreateProcedures();
            this.ownerAnimals = new Dictionary<string, List<string>>();
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal animal = CheckIsAnimalInHotel(name);

            this.procedures["Chip"].DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animal = CheckIsAnimalInHotel(name);

            this.procedures["Vaccinate"].DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animal = CheckIsAnimalInHotel(name);

            this.procedures["Fitness"].DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animal = CheckIsAnimalInHotel(name);

            this.procedures["Play"].DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animal = CheckIsAnimalInHotel(name);

            this.procedures["DentalCare"].DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animal = CheckIsAnimalInHotel(name);

            this.procedures["NailTrim"].DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = CheckIsAnimalInHotel(animalName);

            this.hotel.Adopt(animalName, owner);

            if (!ownerAnimals.ContainsKey(owner))
            {
                ownerAnimals[owner] = new List<string>();
            }
            ownerAnimals[owner].Add(animalName);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            return procedures[type].History();
        }

        public string OwnerAdoptedAnimals()
        {
            StringBuilder report = new StringBuilder();
            foreach (var item in this.ownerAnimals.OrderBy(a => a.Key))
            {
                report.AppendLine($"--Owner: {item.Key}");
                report.AppendLine("    - Adopted animals: " + string.Join(" ", item.Value));

            }
            
            return report.ToString().TrimEnd();
        }
        private IAnimal CheckIsAnimalInHotel(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            return this.hotel.Animals[name];
        }

        private void CreateProcedures()
        {
            this.procedures.Add("Chip", new Chip());
            this.procedures.Add("DentalCare", new DentalCare());
            this.procedures.Add("Fitness", new Fitness());
            this.procedures.Add("NailTrim", new NailTrim());
            this.procedures.Add("Play", new Play());
            this.procedures.Add("Vaccinate", new Vaccinate());
        }
    }
}