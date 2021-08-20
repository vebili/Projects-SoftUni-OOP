using System;

namespace AnimalFarm.Models
{
    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        public Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
                }
                this.age = value;
            }
        }

        public double ProductPerDay
        {
            get
            {
                if (this.Age >= 0 && this.Age <= 3)
                {
                    return 1.5;

                }
                if (this.Age >= 4 && this.Age <= 7)
                {
                    return 2;
                }
                else if (this.Age >= 8 && this.Age <= 11)
                {
                    return 1;
                }

                return 0.75;
            }
        }
    }
}
