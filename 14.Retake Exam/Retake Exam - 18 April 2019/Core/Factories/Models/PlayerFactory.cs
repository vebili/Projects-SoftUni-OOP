namespace PlayersAndMonsters.Core.Factories.Models
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using Repositories.Contracts;
    using Repositories.Models;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type typePlayerToAdd = Assembly
                                   .GetExecutingAssembly()
                                   .GetTypes()
                                   .FirstOrDefault(t => t.Name == type);

            if (typePlayerToAdd == null)
            {
                throw new ArgumentException("Invalid type of player!");
            }

            ICardRepository cards = new CardRepository();

            object[] args = { cards, username };

            IPlayer player = (IPlayer)Activator.CreateInstance(typePlayerToAdd, args);

            return player;
        }
    }
}