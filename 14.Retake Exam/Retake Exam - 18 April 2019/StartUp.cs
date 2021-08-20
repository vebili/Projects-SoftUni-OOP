namespace PlayersAndMonsters
{
    using Core;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            Engine engine = new Engine();
            engine.Run();
        }
    }
}