namespace DungeonsAndCodeWizards.Entities.Characters
{
    using System;
    using Bags;
    using Items;

    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private Bag bag;
        private double abilityPoints;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            Faction = faction;
            IsAlive = true;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth
        {
            get => this.baseHealth;
            private set => this.baseHealth = value;
        }

        public double Health
        {
            get => this.health;
            set => this.health = Math.Max(0, Math.Min(this.BaseHealth, value));
        }

        public double BaseArmor
        {
            get => this.baseArmor;
            private set => this.baseArmor = value;
        }

        public double Armor
        {
            get => this.armor;
            set => this.armor = Math.Max(0, Math.Min(this.BaseArmor, value));
        }

        public double AbilityPoints
        {
            get => this.abilityPoints;
            private set => this.abilityPoints = value;
        }

        public Bag Bag
        {
            get => this.bag;
            private set => bag = value;
        }

        public Faction Faction { get; private set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier => 0.2;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double leftPoints = hitPoints - this.Armor;

            this.Armor -= hitPoints;

            if (leftPoints > 0)
            {
                this.Health -= leftPoints;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            this.EnsureAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.EnsureAlive();
            character.EnsureAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.EnsureAlive();

            this.Bag.AddItem(item);
        }
        public override string ToString()
        {
            const string format = "{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}";

            var result = string.Format(format,
                this.Name,
                this.Health,
                this.BaseHealth,
                this.Armor,
                this.BaseArmor,
                this.IsAlive ? "Alive" : "Dead");

            return result;
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}