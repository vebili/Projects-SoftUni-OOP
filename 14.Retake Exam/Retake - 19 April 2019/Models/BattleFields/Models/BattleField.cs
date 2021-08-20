namespace PlayersAndMonsters.Models.BattleFields.Models
{
    using Common;
    using Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Players.Models;
    using System;
    using System.Linq;
    using Cards.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.ExcDeadPlayer);
            }

            CheckIfBeginner(attackPlayer);
            CheckIfBeginner(enemyPlayer);

            TakeBonus(attackPlayer);
            TakeBonus(enemyPlayer);

            while (true)
            {
                int attackPlayerDamage = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                int enemyPlayerDamage = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(attackPlayerDamage);
                
                if (IsDead(enemyPlayer)) break;
                
                attackPlayer.TakeDamage(enemyPlayerDamage);
                
                if (IsDead(attackPlayer)) break;
            }
        }

        private static bool IsDead(IPlayer player)
        {
            if (player.IsDead)
            {
                return true;
            }

            return false;
        }

        private void TakeBonus(IPlayer player)
        {
            foreach (ICard card in player.CardRepository.Cards)
            {
                player.Health += card.HealthPoints;
            }
        }

        private static void CheckIfBeginner(IPlayer player)
        {
            if (player.GetType().Name == nameof(Beginner))
            {
                player.Health += 40;

                foreach (ICard card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}