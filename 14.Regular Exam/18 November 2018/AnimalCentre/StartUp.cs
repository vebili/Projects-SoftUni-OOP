namespace AnimalCentre
{
    using System;
    using Core.Entities;
    using Models.Contracts;
    using Models.Entities.Animals;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();

        }
    }
}