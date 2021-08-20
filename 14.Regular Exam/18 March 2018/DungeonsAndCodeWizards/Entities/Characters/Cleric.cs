namespace DungeonsAndCodeWizards.Entities.Characters
{
    using System;
    using Bags;
    using Contracts;

    public class Cleric : Character, IHealable
    {
        private const double ConstBaseHealth = 50;
        private const double ConstBaseArmor = 25;
        private const double ConstAbilityPoints = 40;
        public Cleric(string name, Faction faction) : base(name, ConstBaseHealth, ConstBaseArmor, ConstAbilityPoints, new Backpack(), faction)
        {
        }

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character.Faction != this.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}