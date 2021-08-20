namespace PlayersAndMonsters.Models.Cards.Models
{
    public class MagicCard : Card
    {
        private const int DamagePointsMagicCard = 5;
        private const int HealthPointsMagicCard = 80;
        public MagicCard(string name) 
            : base(name, DamagePointsMagicCard, HealthPointsMagicCard)
        {
        }
    }
}