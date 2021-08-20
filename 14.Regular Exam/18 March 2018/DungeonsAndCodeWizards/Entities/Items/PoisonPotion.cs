namespace DungeonsAndCodeWizards.Entities.Items
{
    using Characters;

    public class PoisonPotion : Item
    {
        private const int ConstWeight = 5;
        public PoisonPotion() 
            : base(ConstWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}