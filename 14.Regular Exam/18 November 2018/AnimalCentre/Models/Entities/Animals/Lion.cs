namespace AnimalCentre.Models.Entities.Animals
{
    using System;

    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            return String.Format(base.ToString(), nameof(Lion), Name, Happiness, Energy);
        }
    }
}