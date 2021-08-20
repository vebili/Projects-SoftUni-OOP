namespace PlayersAndMonsters.Core.Factories.Models
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    using PlayersAndMonsters.Models.Cards.Contracts;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type typeCardToAdd = Assembly
                                   .GetExecutingAssembly()
                                   .GetTypes()
                                   .FirstOrDefault(t => t.Name.ToLower() == type.ToLower() + "card");

            if (typeCardToAdd == null)
            {
                throw new ArgumentException("Invalid type of card!");
            }

            object[] args = { name };

            ICard card = (ICard)Activator.CreateInstance(typeCardToAdd, args);

            return card;
        }
    }
}