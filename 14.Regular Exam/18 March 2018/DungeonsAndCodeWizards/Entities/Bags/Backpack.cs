namespace DungeonsAndCodeWizards.Entities.Bags
{
    public class Backpack : Bag
    {
        private const int ConstCapacity = 100;
        public Backpack() 
            : base(ConstCapacity)
        {
        }
    }
}