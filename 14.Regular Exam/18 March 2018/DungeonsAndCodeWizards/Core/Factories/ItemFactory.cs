namespace DungeonsAndCodeWizards.Core.Factories
{
    using Entities.Items;
    using System;

    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            Item item;

            if (type == "ArmorRepairKit")
            {
                item = new ArmorRepairKit();
            }
            else if (type == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (type == "PoisonPotion")
            {
                item = new PoisonPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{type}\"!");
            }

            return item;
        }
    }
}