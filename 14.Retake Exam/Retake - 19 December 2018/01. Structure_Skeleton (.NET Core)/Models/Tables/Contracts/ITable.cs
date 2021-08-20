﻿namespace SoftUniRestaurant.Models.Tables.Contracts
{
    using System.Collections.Generic;

    using Drinks.Contracts;

    using Foods.Contracts;

    public interface ITable
    {
        IReadOnlyCollection<IFood> FoodOrders { get; }
        IReadOnlyCollection<IDrink> DrinkOrders { get; }
        int TableNumber { get; }
        int Capacity { get; }
        int NumberOfPeople { get; }
        decimal PricePerPerson { get; }
        bool IsReserved { get; }
        decimal Price { get; }

        void Reserve(int numberOfPeople);
        void OrderFood(IFood food);
        void OrderDrink(IDrink drink);
        decimal GetBill();
        void Clear();
        string GetFreeTableInfo();
        string GetOccupiedTableInfo();
    }
}
