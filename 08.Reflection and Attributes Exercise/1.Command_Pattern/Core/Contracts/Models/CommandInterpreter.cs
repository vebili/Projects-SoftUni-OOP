namespace CommandPattern.Core.Contracts.Models
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string _commandSufix = "Command";

        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];
            string[] commandArrgs = tokens[1..];

            //ICommand command = default;
            //if (commandName == "Hello")
            //{
            //    command = new HelloCommand();
            //}
            //else if (commandName == "Exit")
            //{
            //    command = new ExitCommand();
            //}

            Type commandType = Assembly
                 .GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == $"{commandName}{_commandSufix}");

            //ICommand instance = (ICommand)(Activator.CreateInstance("CommandPattern", $"CommandPattern.Core.Contracts.Models.Commands.{commandName}Command").Unwrap());
            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command type");
            }
            ICommand command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(commandArrgs);
            return result;
        }
    }
}
