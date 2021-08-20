namespace SoftUniRestaurant.Core.Factories
{
    using System;
    using Models.Drinks.Contracts;
    using Models.Drinks.Entities;

    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink;

            if (type == "FuzzyDrink")
            {
                drink = new FuzzyDrink(name, servingSize, brand);
            }
            else if (type == "Juice")
            {
                drink = new Juice(name, servingSize, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, servingSize, brand);
            }
            else if (type == "Alcohol")
            {
                drink = new Alcohol(name, servingSize, brand);
            }
            else
            {
                throw new InvalidOperationException("Wrong type of drink!");
            }

            return drink;
        }
    }
}