namespace AnimalCentre.Models.Entities.Procedures
{
    using Contracts;

    public class NailTrim : Procedure
    {
        private const int RemoveHappiness = 7;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);

            animal.Happiness -= RemoveHappiness;
            
            procedureHistory.Add(animal);
        }
    }
}