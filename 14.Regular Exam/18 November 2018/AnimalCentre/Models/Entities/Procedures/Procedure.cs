namespace AnimalCentre.Models.Entities.Procedures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }
        public string History()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{this.GetType().Name}");

            foreach (var animal in procedureHistory.OrderBy(a => a.Name))
            {
                report.AppendLine(animal.ToString());
            }

            return report.ToString().TrimEnd();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void CheckTime(int time, IAnimal animal)
        {
            if (time <= animal.ProcedureTime)
            {
                animal.ProcedureTime -= time;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
    }
}