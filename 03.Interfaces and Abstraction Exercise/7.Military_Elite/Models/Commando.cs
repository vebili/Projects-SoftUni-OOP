using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class Commando: SpecialisedSoldier , ICommando
    {
        private List< IMissions> missions { get; }

        public Commando(
            string id, 
            string firstname, 
            string lastName, 
            decimal salary, 
            Corps corps) 
            : base(id, firstname, lastName, salary, corps)
        {
            this.missions = new List<IMissions>();
        }

        public IReadOnlyCollection<IMissions> Missions => this.missions.AsReadOnly();

        public void AddMission(IMissions mission)
        {
            this.missions.Add(mission);
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
           sb.AppendLine(base.ToString());

           sb.AppendLine("Missions:");

           foreach (var mission in this .Missions )
           {
               sb.AppendLine($"  {mission}");
           }

           return sb.ToString().TrimEnd();
        }
    }
}
