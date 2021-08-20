namespace AnimalCentre.Models.Entities.Hotel
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Hotel : IHotel
    {
        private readonly Dictionary<string, IAnimal> animals;
        private const int Capacity = 10;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals;

        public void Accommodate(IAnimal animal)
        {
            if (this.Animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animalToRemove = this.animals[animalName];
            animalToRemove.Owner = owner;
            animalToRemove.IsAdopt = true;

            this.animals.Remove(animalName);
        }
    }
}