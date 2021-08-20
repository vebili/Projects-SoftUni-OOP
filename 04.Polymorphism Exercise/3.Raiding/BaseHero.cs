namespace _3.Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name,int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string  Name { get; }

        public int  Power { get;  }

        public abstract string CastAbility();
    }
}
