using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories.Models
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public int Count => this.cards.Count;
        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();
        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.ExcAddNullCard);
            }

            if (this.cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExcAddExistingCard, card.Name));
            }

            this.cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (card == null || cards.All(c => c.Name != card.Name))
            {
                throw new ArgumentException(ExceptionMessages.ExcRemoveCard);
            }

            this.cards.RemoveAll(c => c.Name == card.Name);
            return true;
        }

        public ICard Find(string name)
        {
            return this.cards.FirstOrDefault(c => c.Name == name);
        }
    }
}