namespace AnimalCentre.Models.Entities.Procedures
{
    using Contracts;

    public class Fitness : Procedure
    {
        private const int RemoveHappiness = 3;
        private const int AddEnergy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);

            animal.Happiness -= RemoveHappiness;
            animal.Energy += AddEnergy;

            procedureHistory.Add(animal);
        }
    }
}