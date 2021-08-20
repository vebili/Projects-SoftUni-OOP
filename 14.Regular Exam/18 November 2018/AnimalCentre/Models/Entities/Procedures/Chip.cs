namespace AnimalCentre.Models.Entities.Procedures
{
    using System;
    using Contracts;

    public class Chip : Procedure
    {
        private const int RemoveHappiness = 5;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            
            animal.Happiness -= RemoveHappiness;
            animal.IsChipped = true;

            base.procedureHistory.Add(animal);
        }
    }
}