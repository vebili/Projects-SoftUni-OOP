namespace MortalEngines.Entities
{
    using System.Text;
    using Contracts;

    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100.0;
        private const int ChangeAttackPoints = 40;
        private const int ChangeDeffencePoints = 30;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(
                name,
                InitialHealthPoints,
                attackPoints - ChangeAttackPoints, 
                defensePoints + ChangeDeffencePoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public string DefenseModeString => DefenseMode ? "ON" : "OFF"; 

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += ChangeAttackPoints;
                this.DefensePoints -= ChangeDeffencePoints;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= ChangeAttackPoints;
                this.DefensePoints += ChangeDeffencePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {this.DefenseModeString}");
            
            return sb.ToString().TrimEnd();
        }
    }
}