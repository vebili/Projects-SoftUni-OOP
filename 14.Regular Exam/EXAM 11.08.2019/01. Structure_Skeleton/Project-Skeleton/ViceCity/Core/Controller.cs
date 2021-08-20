namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Guns;
    using Models.Guns.Contracts;
    using Models.Neghbourhoods;
    using Models.Players;
    using Models.Players.Contracts;
    using Repositories;

    public class Controller : IController
    {
        private MainPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private GunRepository gunRepository;
        private GangNeighbourhood neighbourhood;
        private List<IPlayer> deadPlayers;

        public Controller()
        {
            mainPlayer = new MainPlayer();
            civilPlayers = new List<IPlayer>();
           gunRepository = new GunRepository();
           deadPlayers = new List<IPlayer>();
           neighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);


            this.civilPlayers.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }

            if (gun == null)
            {
                return $"Invalid gun type!";
            }
            else
            {
                gunRepository.Add(gun);

                return $"Successfully added {name} of type: {type}";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Models.Count == 0)
            {
                return $"There are no guns in the queue!";
            }

            IGun gunToAdd = gunRepository.Models.ElementAt(0);

            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gunToAdd);
                gunRepository.Remove(gunToAdd);
                return $"Successfully added {gunToAdd.Name} to the Main Player: Tommy Vercetti";
            }

            if (this.civilPlayers.All(p => p.Name != name))
            {
                return $"Civil player with that name doesn't exists!";
            }

            IPlayer playerToBeAddedGun = this.civilPlayers.First(p => p.Name == name);

            playerToBeAddedGun.GunRepository.Add(gunToAdd);
            gunRepository.Remove(gunToAdd);
            return $"Successfully added {gunToAdd.Name} to the Civil Player: {playerToBeAddedGun.Name}";
        }

        public string Fight()
        {
            if (civilPlayers.Count > 0)
            {
                neighbourhood.Action(mainPlayer, civilPlayers);

                for (int i = 0; i < civilPlayers.Count; i++)
                {
                    if (!civilPlayers[i].IsAlive)
                    {
                        deadPlayers.Add(civilPlayers[i]);
                        civilPlayers.Remove(civilPlayers[i]);
                        i--;
                    }
                }
            }
            

            if (mainPlayer.LifePoints == 100 && deadPlayers.Count == 0)
            {
                return "Everything is okay!";
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {mainPlayer.LifePoints}!")
                    .AppendLine($"Tommy has killed: {deadPlayers.Count} players!")
                    .AppendLine($"Left Civil Players: {civilPlayers.Count}!");

                return sb.ToString().TrimEnd();
            }
        }
    }
}