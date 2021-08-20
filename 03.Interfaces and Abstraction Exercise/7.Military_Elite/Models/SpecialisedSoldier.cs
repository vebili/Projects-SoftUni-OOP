using System;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier:Private ,ISpecialisedSoldier 
    {
        protected SpecialisedSoldier(
            string id, 
            string firstname, 
            string lastName, 
            decimal salary, Corps corps) 
            : base(id, firstname, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; private set; }

        public override string ToString()
        {
            return base.ToString() +
                   Environment.NewLine +
                   $"Corps: {this.Corps}";
        }
    }
}
