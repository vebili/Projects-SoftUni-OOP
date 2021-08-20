namespace AnimalCentre.Models.Entities.Animals
{
    using System;

    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return String.Format(base.ToString(), nameof(Cat), Name, Happiness, Energy);
        }
    }
}