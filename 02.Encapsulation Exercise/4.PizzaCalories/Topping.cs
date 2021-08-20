using System.Collections.Generic;

namespace _4.PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfValueIsNotAllowed(
                    new HashSet<string> { "meat", "veggies", "cheese", "sauce" },
                    value.ToLower(),
                    $"Cannot place {value} on top of your pizza.");

                this.name = value;
            }
        }
        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(MinWeight,
                    MaxWeight,
                    value,
                    $"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");

                this.weight = value;
            }
        }
        public double GetCalories()
        {
            var modifier = GetModifier();
            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameLower = this.Name.ToLower();
            if (nameLower == "meat")
            {
                return 1.2;
            }

            if (nameLower == "veggies")
            {
                return 0.8;
            }

            if (nameLower == "cheese")
            {
                return 1.1;
            }
            return 0.9;
        }
    }
}
