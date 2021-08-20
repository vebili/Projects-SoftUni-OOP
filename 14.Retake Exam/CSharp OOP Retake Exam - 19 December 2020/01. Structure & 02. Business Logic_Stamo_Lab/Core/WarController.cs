using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly IList<Character> characterParty;

        private readonly Stack<Item> itemPool;

        public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            switch (args[0])
            {
                case "Warrior":
                    characterParty.Add(new Warrior(args[1]));
                    break;
                case "Priest":
                    characterParty.Add(new Priest(args[1]));
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }

            return string.Format(SuccessMessages.JoinParty, args[1]);
        }

        public string AddItemToPool(string[] args)
        {
            switch (args[0])
            {
                case "HealthPotion":
                    itemPool.Push(new HealthPotion());
                    break;
                case "FirePotion":
                    itemPool.Push(new FirePotion());
                    break;
                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, args[0]));
            }

            return string.Format(SuccessMessages.AddItemToPool, args[0]);
        }

        public string PickUpItem(string[] args)
        {
            Character character = characterParty.FirstOrDefault(c => c.Name == args[0]);

            if (character == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = itemPool.Pop();
            character.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, character.Name, item, GetType().Name);
        }

        public string UseItem(string[] args)
        {
            Character character = characterParty.FirstOrDefault(c => c.Name == args[0]);
            if (character == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);
            }

            Item item = character.Bag.GetItem(args[1]);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            var characters = characterParty
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health);

            foreach (var item in characters)
            {
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats,
                    item.Name, item.Health, item.BaseHealth, item.Armor, item.BaseArmor, item.IsAlive ? "Alive" : "Dead"));
            }

            return sb.ToString();
        }

        public string Attack(string[] args)
        {
            Character attacker = characterParty.FirstOrDefault(c => c.Name == args[0]);
            Character receiver = characterParty.FirstOrDefault(c => c.Name == args[1]);

            if (attacker == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);

            }
            if (receiver == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[1]);
            }

            Warrior warrior = attacker as Warrior;

            if (warrior == null)
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, args[0]);
            }

            warrior.Attack(receiver);

            string output = string.Format(SuccessMessages.AttackCharacter, warrior.Name, receiver.Name,
                warrior.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor,
                receiver.BaseArmor);

            if (receiver.Health == 0)
            {
                string temp = string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name);
                output = $"{output}\n{temp}";
            }

            return output;
        }

        public string Heal(string[] args)
        {
            Character healer = characterParty.FirstOrDefault(c => c.Name == args[0]);
            Character receiver = characterParty.FirstOrDefault(c => c.Name == args[1]);

            if (healer == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[0]);

            }
            if (receiver == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, args[1]);
            }

            Priest priest = healer as Priest;

            if (priest == null)
            {
                throw new ArgumentException(ExceptionMessages.HealerCannotHeal, args[0]);
            }

            return string.Format(SuccessMessages.HealCharacter, priest.Name, receiver.Name, priest.AbilityPoints,
                receiver.Name, receiver.Health);
        }
    }
}
