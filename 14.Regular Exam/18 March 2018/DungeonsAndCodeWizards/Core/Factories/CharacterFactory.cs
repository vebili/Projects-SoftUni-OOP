namespace DungeonsAndCodeWizards.Core.Factories
{
    using System;
    using Entities.Characters;

    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            Faction newFaction;

            bool isParsed = Enum.TryParse<Faction>(faction, out newFaction);

            if (!isParsed)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }


            Character character;

            if (type == "Warrior")
            {
                character = new Warrior(name, newFaction);
            }
            else if (type == "Cleric")
            {
                character = new Cleric(name, newFaction);
            }
            else
            {
                throw new ArgumentException($"Invalid character \"{type}\"!");
            }

            return character;
        }
    }
}