using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private readonly double baseHealth;

        private readonly double baseArmor;

        protected readonly double abilityPoints;

        private double health;
        private double armor;

        public string Name { get; }

        public double BaseArmor {
            get
            {
                return baseArmor;
            }

        }public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
        }

        public double BaseHealth {
            get
            {
                return baseHealth;
            }
        }

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > baseHealth)
                {
                    health = baseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public IBag Bag { get; }

        public bool IsAlive { get; set; } = true;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
            }

            this.Name = name;
            this.baseHealth = health;
            this.Health = health;
            this.baseArmor = armor;
            this.Armor = armor;
            this.abilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public virtual void TakeDamage(double hitpoints)
        {
            this.EnsureAlive();
            double healthReduce = hitpoints - this.Armor;
            this.Armor -= hitpoints;
            if (healthReduce > 0)
            {
                this.Health -= healthReduce;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public virtual void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}