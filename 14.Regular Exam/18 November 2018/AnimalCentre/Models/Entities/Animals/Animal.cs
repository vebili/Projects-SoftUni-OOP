namespace AnimalCentre.Models.Entities.Animals
{
    using System;
    using Contracts;

    public abstract class Animal : IAnimal
    {
        private int happines;
        private int energy;
        protected Animal(string name,  int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }
        public string Name { get; private set; }

        public int Happiness
        {
            get => this.happines;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                this.happines = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsAdopt { get; set; }
        public bool IsChipped { get; set; }
        public bool IsVaccinated { get; set; }

        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";


            //Judge иска във всяко дете да се override ToString(), затова по-долния вариант дава грешка!!!

            //return $"    Animal type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}