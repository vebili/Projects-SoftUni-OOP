namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        public Rifle(string name) 
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


            if (this.BulletsPerBarrel >= 5)
            {
                this.BulletsPerBarrel -= 5;
                return 5;
            }
            else
            {
                int bulletsToReturn = this.BulletsPerBarrel;
                this.BulletsPerBarrel = 0;
                return bulletsToReturn;
            }
        }
    }
}