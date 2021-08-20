namespace AnimalCentre.Models.Entities.Animals
{
    using System;

    public class Dog : Animal
    {
        public Dog(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            return String.Format(base.ToString(), nameof(Dog), Name, Happiness, Energy);
        }

        
    }
}