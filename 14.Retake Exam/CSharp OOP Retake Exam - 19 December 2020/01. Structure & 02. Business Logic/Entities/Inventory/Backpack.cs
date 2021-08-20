namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int BackPackCapacity = 100;
        public Backpack() : base(BackPackCapacity)
        {
        }
    }
}
