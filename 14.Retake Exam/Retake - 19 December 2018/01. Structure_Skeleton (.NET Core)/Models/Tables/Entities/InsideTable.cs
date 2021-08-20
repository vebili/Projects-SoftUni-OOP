namespace SoftUniRestaurant.Models.Tables.Entities
{
    public class InsideTable : Table
    {
        //Judge гърми ако няма 0 накрая на 2.50
        private const decimal InitialPricePerPerson = 2.50m;
        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}