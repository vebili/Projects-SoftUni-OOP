namespace SoftUniRestaurant.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Factories;
    using Models.Drinks.Contracts;
    using Models.Foods.Contracts;
    using Models.Tables.Contracts;

    public class RestaurantController
    {
        private List<IFood> menu;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;
        private decimal totalIncome;
        public RestaurantController()
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
            this.totalIncome = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = foodFactory.CreateFood(type, name, price);

            this.menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool" ;
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = drinkFactory.CreateDrink(type, name, servingSize, brand);

            this.drinks.Add(drink);

            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);

            this.tables.Add(table);

            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable tableToReserve =
                this.tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (tableToReserve == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                tableToReserve.Reserve(numberOfPeople);

                return $"Table {tableToReserve.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable tableToOrderFood = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (tableToOrderFood == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IFood foodToBeOrdered = this.menu.FirstOrDefault(f => f.Name == foodName);

            if (foodToBeOrdered == null)
            {
                return $"No {foodName} in the menu";
            }

            tableToOrderFood.OrderFood(foodToBeOrdered);
            return $"Table {tableToOrderFood.TableNumber} ordered {foodToBeOrdered.Name}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable tableToOrderDrink = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (tableToOrderDrink == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            IDrink drinkToBeOrdered = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drinkToBeOrdered == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            tableToOrderDrink.OrderDrink(drinkToBeOrdered);
            return $"Table {tableToOrderDrink.TableNumber} ordered {drinkToBeOrdered.Name} {drinkToBeOrdered.Brand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable tableToLeave = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (tableToLeave == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            decimal bill = tableToLeave.GetBill();
            this.totalIncome += bill;
            tableToLeave.Clear();

            return $"Table: {tableToLeave.TableNumber}"
                   + Environment.NewLine
                   + $"Bill: {bill:f2}";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder info = new StringBuilder();

            foreach (var table in this.tables.Where(t => !t.IsReserved))
            {
                info.AppendLine(table.GetFreeTableInfo());
            }

            return info.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder info = new StringBuilder();

            foreach (var table in this.tables.Where(t => t.IsReserved))
            {
                info.AppendLine(table.GetOccupiedTableInfo());
            }

            return info.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }
    }
}
