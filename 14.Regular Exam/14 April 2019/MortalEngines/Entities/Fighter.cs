namespace MortalEngines.Entities
{
    using System.Text;
    using Contracts;

    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200.0;
        private const int ChangeAttackPoints = 50;
        private const int ChangeDeffencePoints = 25;
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(
                name,
                InitialHealthPoints,
                attackPoints + ChangeAttackPoints,
                defensePoints - ChangeDeffencePoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public string AggressiveModeString => this.AggressiveMode ? "ON" : "OFF"; 

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= ChangeAttackPoints;
                this.DefensePoints += ChangeDeffencePoints;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += ChangeAttackPoints;
                this.DefensePoints -= ChangeDeffencePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {this.AggressiveModeString}");
            
            return sb.ToString().TrimEnd();
        }
    }
}