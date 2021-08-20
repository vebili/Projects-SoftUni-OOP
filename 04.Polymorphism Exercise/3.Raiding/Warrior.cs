namespace _3.Raiding
{
    public class Warrior : BaseHero
    {
        private const int power = 100;

        public Warrior(string name) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
