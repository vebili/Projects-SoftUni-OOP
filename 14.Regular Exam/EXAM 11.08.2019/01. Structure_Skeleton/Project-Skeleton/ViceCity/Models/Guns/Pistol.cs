namespace ViceCity.Models.Guns
{
    using System;

    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
            this.TotalBullets -= InitialBulletsPerBarrel;
        }

        public override int Fire()
        {
            if (!this.CanFire)
            {
                return 0;
            }

            if (this.BulletsPerBarrel == 0)
            {
                if (this.TotalBullets >= InitialBulletsPerBarrel)
                {
                    this.BulletsPerBarrel = InitialBulletsPerBarrel;
                    this.TotalBullets -= InitialBulletsPerBarrel;

                }
                else if (this.TotalBullets > 0)
                {
                    this.BulletsPerBarrel = this.TotalBullets;
                    this.TotalBullets = 0;
                }
                else
                {
                    return 0;
                }
            }

            this.BulletsPerBarrel -= 1;

            return 1;
        }

    }
}