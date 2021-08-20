namespace DungeonsAndCodeWizards.Entities.Bags
{
    using Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private readonly List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            items = new List<Item>();

            this.Capacity = capacity;
        }
        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();
        public int Capacity { get; protected set; }
        public int Load => this.items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (this.Items.All(i => i.GetType().Name != name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = this.items.First(i => i.GetType().Name == name);

            this.items.Remove(item);

            return item;
        }
    }
}