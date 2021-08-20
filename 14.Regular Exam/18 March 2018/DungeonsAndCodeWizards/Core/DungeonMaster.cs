namespace DungeonsAndCodeWizards.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Entities.Characters;
    using Entities.Characters.Contracts;
    using Entities.Items;
    using Factories;

    public class DungeonMaster
    {
        private int lastSurvivorRounds = 0;
        private ItemFactory itemFactory;
        private CharacterFactory characterFactory;
        private Dictionary<string, Character> characterParty;
        private Stack<Item> itemPool;

        public DungeonMaster()
        {
            characterParty = new Dictionary<string, Character>();
            itemPool = new Stack<Item>();

            itemFactory = new ItemFactory();
            characterFactory = new CharacterFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = characterFactory.CreateCharacter(faction, characterType, name);

            characterParty[name] = character;

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string type = args[0];

            Item item = itemFactory.CreateItem(type);

            itemPool.Push(item);

            return $"{type} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = FindCharacter(characterName);

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = itemPool.Pop();

            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = FindCharacter(characterName);

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder stats = new StringBuilder();

            foreach (var character in characterParty
                .Values
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health))
            {
                stats.AppendLine(character.ToString());
            }

            return stats.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = FindCharacter(attackerName);
            Character receiver = FindCharacter(receiverName);

            //Checks if attacker can be cast to IAttackable if so the 
            //new variable that IAttackable is attackingCharacter
            if (!(attacker is IAttackable attackingCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attackingCharacter.Attack(receiver);

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = FindCharacter(healerName);
            Character healingReceiver = FindCharacter(healingReceiverName);

            //Checks if healer can be cast to IHealable if so the 
            //new variable that IHealable is healingCharacter
            if (!(healer is IHealable healingCharacter))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            healingCharacter.Heal(healingReceiver);

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!");

            return result.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            List<Character> aliveCharacters = characterParty
                                    .Select(c => c.Value)
                                    .Where(c => c.IsAlive)
                                    .ToList();

            StringBuilder report = new StringBuilder();

            foreach (var character in aliveCharacters)
            {
                double previousHealth = character.Health;

                character.Rest();

                double currentHealth = character.Health;

                report.AppendLine($"{character.Name} rests ({previousHealth} => {currentHealth})");
            }

            if (aliveCharacters.Count <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return report.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            bool oneOrZeroSurvivorsLeft = this.characterParty.Count(c => c.Value.IsAlive) <= 1;

            bool lastSurvivorSurvivedTooLong = this.lastSurvivorRounds > 1;

            return oneOrZeroSurvivorsLeft && lastSurvivorSurvivedTooLong;
        }

        private Character FindCharacter(string name)
        {
            if (!this.characterParty.ContainsKey(name))
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return characterParty[name];
        }
    }
}