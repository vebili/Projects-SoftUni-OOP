namespace DungeonsAndCodeWizards.Entities.Items
{
    using Characters;

    public class ArmorRepairKit : Item
    {
        private const int ConstWeight = 10;
        public ArmorRepairKit() 
            : base(ConstWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Armor = character.BaseArmor;
        }
    }
}