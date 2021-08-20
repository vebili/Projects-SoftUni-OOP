namespace MortalEngines.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Common;
    using Contracts;

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.ExcNullPilotName);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<IMachine> Machines => this.machines.AsReadOnly();

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException(ExceptionMessages.ExcAddNullMachine);
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{this.Name} - {this.Machines.Count} machines");

            foreach (var machine in this.Machines)
            {
                report.AppendLine(machine.ToString());
            }

            return report.ToString().TrimEnd();
        }
    }
}