namespace DungeonsAndCodeWizards.Entities.Characters
{
    using System;
    using Bags;
    using Contracts;

    public class Warrior : Character, IAttackable
    {
        private const double ConstBaseHealth = 100;
        private const double ConstBaseArmor = 50;
        private const double ConstAbilityPoints = 40;

        public Warrior(string name, Faction faction) 
            : base(name, ConstBaseHealth, ConstBaseArmor, ConstAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character.Name == this.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}