using System;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(
            string id,
            string firstname,
            string lastName, int codeNumber)
            : base(id, firstname, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() +
                   Environment.NewLine +
                   $"Code Number: {this.CodeNumber}";
        }
    }
}
