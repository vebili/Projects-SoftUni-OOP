namespace AnimalCentre.Core.Entities
{
    using System;
    using Contracts;
    using Models.Contracts;
    using Models.Entities.Animals;

    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name,  int energy, int happiness, int procedureTime)
        {
            IAnimal animal;

            switch (type)
            {
                case "Cat": 
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;

                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                    
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                    

                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
                    

                default:
                    throw new ArgumentException("Invalid type of animal!");
            }

            return animal;
        }
    }
}