namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            PlayerShoots(mainPlayer, civilPlayers);

            if (civilPlayers.Count == 0)
            {
                return;
            }

            List<IPlayer> leftPlayers = new List<IPlayer>();

            foreach (var civilPlayer in civilPlayers)
            {
                if (civilPlayer.IsAlive)
                {
                    leftPlayers.Add(civilPlayer);
                }
            }

            if (leftPlayers.Count > 0)
            {
                foreach (var player in leftPlayers)
                {
                    CivilPlayerShoots(player, mainPlayer);

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }
            }
        }

        private void CivilPlayerShoots(IPlayer player, IPlayer mainPlayer)
        {
            while (true)
            {
                if (!mainPlayer.IsAlive)
                {
                    break;
                }

                var currentCivilGun = player.GunRepository.Models.FirstOrDefault(g => g.CanFire);

                if (currentCivilGun == null)
                {
                    break;
                }
                
                mainPlayer.TakeLifePoints(currentCivilGun.Fire());
            }
        }

        private static void PlayerShoots(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                if (civilPlayers.Count == 0)
                {
                    break;
                }

                var currentMainGun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire);

                if (currentMainGun == null)
                {
                    break;
                }

                IPlayer target = civilPlayers.FirstOrDefault(t => t.IsAlive);

                if (target == null)
                {
                    break;
                }

                target.TakeLifePoints(currentMainGun.Fire());
            }
        }
    }
}