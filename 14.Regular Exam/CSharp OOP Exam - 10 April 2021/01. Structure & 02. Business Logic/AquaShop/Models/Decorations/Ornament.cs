namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int OrnamentComfort = 1;
        private const decimal OrnamentPrice = 5.0m;

        public Ornament()
            : base(OrnamentComfort, OrnamentPrice)
        {
        }
    }
}
