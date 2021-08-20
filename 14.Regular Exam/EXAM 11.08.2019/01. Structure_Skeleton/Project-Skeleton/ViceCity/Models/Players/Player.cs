namespace ViceCity.Models.Players
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Guns.Contracts;
    using Repositories;
    using Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunreRepository;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.gunreRepository = new GunRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                this.name = value;
            }
        }

        public bool IsAlive => this.LifePoints > 0;
        public IRepository<IGun> GunRepository => this.gunreRepository;

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            this.LifePoints = Math.Max(0, this.LifePoints - points);
        }
    }
}