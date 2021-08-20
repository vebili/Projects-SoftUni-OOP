namespace DungeonsAndCodeWizards.Entities.Items
{
    using System;
    using Characters;

    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }
        public int Weight { get; private set; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException($"Must be alive to perform this action!");
            }
        }
    }
}