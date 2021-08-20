namespace _3.Shopping_Spree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get =>this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Name cannot be empty");

                this.name = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                Validator.ThrowIfNumberIsNegative(value, "Money cannot be negative");
                this.cost = value;
            }
        }
    }
}
