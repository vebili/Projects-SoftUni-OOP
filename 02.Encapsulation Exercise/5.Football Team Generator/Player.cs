using System;

namespace _5.FootballTeamGenerator
{
    public class Player
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, GlobalConstants.InvalidNameErrorMessage);

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfNumberIsNotInrange(
                    value,
                    MinStatValue,
                    MaxStatValue,
                    $"{nameof(this.Endurance)} should be between 0 and 100.");

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.ThrowIfNumberIsNotInrange(
                    value,
                    MinStatValue,
                    MaxStatValue,
                    $"{nameof(this.Sprint)} should be between 0 and 100.");

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.ThrowIfNumberIsNotInrange(
                    value,
                    MinStatValue,
                    MaxStatValue,
                    $"{nameof(this.Dribble)} should be between 0 and 100.");

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.ThrowIfNumberIsNotInrange(
                    value,
                    MinStatValue,
                    MaxStatValue,
                    $"{nameof(this.Passing)} should be between 0 and 100.");

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.ThrowIfNumberIsNotInrange(
                    value,
                    MinStatValue,
                    MaxStatValue,
                    $"{nameof(this.Shooting)} should be between 0 and 100.");

                this.shooting = value;
            }
        }
        public double AverageSkillPoints
         => Math.Round(
             (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
    }
}
