namespace PlayersAndMonsters.Repositories.Models
{
    using Common;
    using Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.players.Count;
        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.ExcAddNullPlayer);
            }

            if (this.players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExcAddExistingPlayer, player.Username));
            }

            this.players.Add(player);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null || this.players.All(p => p.Username != player.Username))
            {
                throw new ArgumentException(ExceptionMessages.ExcRemovePlayer);
            }

            this.players.RemoveAll(p => p.Username == player.Username);

            return true;
        }

        public IPlayer Find(string username)
        {
            return this.players.FirstOrDefault(p => p.Username == username);
        }
    }
}