namespace AnimalCentre.Models.Entities.Procedures
{
    using System;
    using Contracts;

    public class Vaccinate : Procedure
    {
        private const int RemoveEnergy = 8;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            
            if (animal.IsVaccinated)
            {
                throw new ArgumentException($"{animal.Name} is already vaccinated");
            }

            animal.Energy -= RemoveEnergy;
            animal.IsVaccinated = true;

            procedureHistory.Add(animal);
        }
    }
}