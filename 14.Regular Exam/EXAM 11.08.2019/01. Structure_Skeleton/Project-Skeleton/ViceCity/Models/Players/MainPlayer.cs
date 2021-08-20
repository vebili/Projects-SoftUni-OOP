namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string ConstName = "Tommy Vercetti";
        private const int ConstLifePoints = 100;

        public MainPlayer() 
            : base(ConstName, ConstLifePoints)
        {
        }
    }
}