﻿namespace _3.Raiding
{
    public class Druid: BaseHero
    {
        private const int power = 80;

        public Druid(string name) 
            : base(name, power)
        {
        }
        
        public override string CastAbility()
        {
            return $"{this .GetType() .Name} - {this.Name} healed for {this.Power}";
        }
    }
}
