namespace AnimalCentre.Models.Entities.Procedures
{
    using Contracts;

    public class DentalCare : Procedure
    {
        private const int AddHappiness = 12;
        private const int AddEnergy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);

            animal.Happiness += AddHappiness;
            animal.Energy += AddEnergy;

            procedureHistory.Add(animal);
        }
    }
}