namespace SoftUniRestaurant.Models.Tables.Entities
{
    public class OutsideTable : Table
    {
        //Judge тук не гърми ако няма 0 накрая на 3.50
        private const decimal InitialPricePerPerson = 3.50m;
        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}