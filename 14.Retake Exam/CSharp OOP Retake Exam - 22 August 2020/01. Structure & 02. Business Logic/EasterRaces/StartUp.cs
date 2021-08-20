using System;
using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            //IChampionshipController controller = null; //new ChampionshipController();
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            //IWriter writer = new StringBuilderWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
            //Console.Clear();
            //Console.WriteLine(writer);
        }
    }
}
