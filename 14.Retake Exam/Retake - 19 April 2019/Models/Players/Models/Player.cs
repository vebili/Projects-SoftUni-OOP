namespace PlayersAndMonsters.Models.Players.Models
{
    using System;
    using Common;
    using Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; protected set; }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.ExcUsername);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ExcHealth);
                }

                this.health = value;
            }
        }

        public bool IsDead => this.Health == 0;
        
        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException(ExceptionMessages.ExcDamagePoints);
            }

            this.Health = Math.Max(0, this.Health - damagePoints);
        }
    }
}