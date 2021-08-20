using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort => this.Decorations.Sum(x => x.Comfort);

        //public ICollection<IDecoration> Decorations { get; }
        public ICollection<IDecoration> Decorations => this.decorations;

        //public ICollection<IFish> Fish { get; private set; }
        public ICollection<IFish> Fish => this.fish;

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);

        public void AddDecoration(IDecoration decoration) => this.Decorations.Add(decoration);

        public void Feed() => this.fish.ForEach(x => x.Eat());
        //{
        //    foreach (IFish fish in this.Fish)
        //    {
        //        fish.Eat();
        //    }
        //}

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({GetType().Name}):");

            sb.AppendLine($"Fish: {(Fish.Any() ? string.Join(", ", GetFishNames()) : "none")}");

            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        private List<string> GetFishNames()
        {
            List<string> list = new List<string>();

            foreach (var fish in Fish)
            {
                list.Add(fish.Name);
            }

            return list;
        }

        //public string GetInfo()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
        //    sb.AppendLine($"Fish: {(this.Fish.Any() ? string.Join(", ", this.Fish.Select(x => x.Name)) : "none")}");
        //    sb.AppendLine($"Decorations: {this.Decorations.Count}");
        //    sb.AppendLine($"Comfort: {this.Comfort}");
        //    return sb.ToString().TrimEnd();
        //}
    }
}

