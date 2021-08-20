namespace SoftUniRestaurant.Core.Factories
{
    using System;
    using Models.Foods.Contracts;
    using Models.Foods.Entities;

    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            IFood food;

            if (type == "Dessert")
            {
                food = new Dessert(name, price);
            }
            else if (type == "Salad")
            {
                food = new Salad(name, price);
            }
            else if (type == "Soup")
            {
                food = new Soup(name, price);
            }
            else if (type == "MainCourse")
            {
                food = new MainCourse(name, price);
            }
            else
            {
                throw new InvalidOperationException("Wrong type of food!");
            }

            return food;
        }
    }
}