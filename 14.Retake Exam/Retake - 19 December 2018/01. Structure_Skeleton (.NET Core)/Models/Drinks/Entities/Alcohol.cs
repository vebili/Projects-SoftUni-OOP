namespace SoftUniRestaurant.Models.Drinks.Entities
{
    public class Alcohol : Drink
    {
        private const decimal AlcoholPrice = 3.50m;
        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}