﻿namespace StorageMaster.Models.Products
{
    using System;

    public abstract class Product
    {
        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
        public double Price
        {
            get => this.price; 

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException ("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set => this.weight = value;
        }
    }
}