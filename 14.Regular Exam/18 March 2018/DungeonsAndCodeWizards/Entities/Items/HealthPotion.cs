namespace DungeonsAndCodeWizards.Entities.Items
{
    using Characters;

    public class HealthPotion : Item
    {
        private const int ConstWeight = 5;
        public HealthPotion() 
            : base(ConstWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += 20;
        }
    }
}