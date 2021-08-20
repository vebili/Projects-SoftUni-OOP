namespace SoftUniRestaurant.Core.Factories
{
    using System;
    using Models.Tables.Contracts;
    using Models.Tables.Entities;

    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            ITable table;

            if (type == "Inside")
            {
                return new InsideTable(tableNumber, capacity);
            }
            else if (type == "Outside")
            {
                return new OutsideTable(tableNumber, capacity);
            }
            else
            {
                throw new InvalidOperationException("Wrong type of table!");
            }

            return table;
        }
    }
}