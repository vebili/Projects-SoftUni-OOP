using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            MuseElf elf = new MuseElf("Elf", 28);
            Console.WriteLine(elf);
        }
    }
}