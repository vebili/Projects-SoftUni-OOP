namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;

    using Common;

    using Contracts;

    using Factories.Models;

    using Models.BattleFields.Models;
    using Models.Cards.Contracts;
    using Models.Players.Contracts;

    using Repositories.Models;

    public class ManagerController : IManagerController
    {
        private readonly PlayerFactory playerFactory;
        private readonly CardFactory cardFactory;
        private readonly PlayerRepository playerRepository;
        private readonly CardRepository cardRepository;
        private readonly BattleField battleField;
        public ManagerController()
        {
            this.playerFactory = new PlayerFactory();
            this.playerRepository = new PlayerRepository();
            this.cardFactory = new CardFactory();
            this.cardRepository = new CardRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return String.Format(ConstantMessages.FightInfo,attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (IPlayer player in this.playerRepository.Players)
            {
                report.AppendLine(String.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health,
                    player.CardRepository.Count));

                foreach (ICard card in player.CardRepository.Cards)
                {
                    report.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                report.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return report.ToString().TrimEnd();
        }
    }
}
