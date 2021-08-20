namespace PlayersAndMonsters.Models.Cards.Models
{
    public class TrapCard : Card
    {
        private const int DamagePointsTrapCard = 120;
        private const int HealthPointsTrapCard = 5;
        public TrapCard(string name) : base(name, DamagePointsTrapCard, HealthPointsTrapCard)
        {
        }
    }
}