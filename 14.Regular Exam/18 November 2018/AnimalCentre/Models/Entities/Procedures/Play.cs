namespace AnimalCentre.Models.Entities.Procedures
{
    using Contracts;

    public class Play : Procedure
    {
        private const int AddHappiness = 12;
        private const int RemoveEnergy = 6;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);

            animal.Happiness += AddHappiness;
            animal.Energy -= RemoveEnergy;

            base.procedureHistory.Add(animal);
        }
    }
}