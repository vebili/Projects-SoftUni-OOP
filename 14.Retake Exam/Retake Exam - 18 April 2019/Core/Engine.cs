namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;

    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private readonly ManagerController managerController;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.managerController = new ManagerController();
        }
        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();
                if (input == "Exit")
                {
                    break;
                }

                StringBuilder result = new StringBuilder();

                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                
                try
                {
                    this.ReadCommand(command, result, commandArgs);
                }
                catch (Exception ex)
                {
                     result.AppendLine(ex.Message);
                }

                this.writer.WriteLine(result.ToString().TrimEnd());
            }
        }

        private void ReadCommand(string command, StringBuilder result, string[] commandArgs)
        {
            switch (command)
            {
                case "AddPlayer":
                    result.AppendLine(managerController.AddPlayer(commandArgs[1], commandArgs[2]));
                    break;

                case "AddCard":
                    result.AppendLine(managerController.AddCard(commandArgs[1], commandArgs[2]));
                    break;

                case "AddPlayerCard":
                    result.AppendLine(managerController.AddPlayerCard(commandArgs[1], commandArgs[2]));
                    break;

                case "Fight":
                    result.AppendLine(managerController.Fight(commandArgs[1], commandArgs[2]));
                    break;

                case "Report":
                    result.AppendLine(managerController.Report());
                    break;

                default:
                    break;
            }
        }
    }
}