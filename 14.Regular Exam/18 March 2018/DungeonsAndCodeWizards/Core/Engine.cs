namespace DungeonsAndCodeWizards.Core
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
		private readonly DungeonMaster dungeonMaster;

		public Engine()
		{
			
			this.dungeonMaster = new DungeonMaster();
		}

		public void Run()
		{
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || this.dungeonMaster.IsGameOver())
                {
                    break;
                }

                StringBuilder result = new StringBuilder();
                
                try
				{
					result.AppendLine(this.ReadCommand(input));
				}
				catch (ArgumentException e)
				{
                    result.AppendLine("Parameter Error: " + e.Message);
				}
				catch (InvalidOperationException e)
				{
                    result.AppendLine("Invalid Operation: " + e.Message);
				}
                
                Console.WriteLine(result.ToString().TrimEnd());
			}

            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
		}

		private string ReadCommand(string command)
		{
			var commandArgs = command.Split();
			var commandName = commandArgs[0];
			var args = commandArgs.Skip(1).ToArray();
            
			switch (commandName)
			{
				case "JoinParty":
					return this.dungeonMaster.JoinParty(args);
					
				case "AddItemToPool":
                    return this.dungeonMaster.AddItemToPool(args);
					
				case "PickUpItem":
                    return this.dungeonMaster.PickUpItem(args);
					
				case "UseItem":
                    return this.dungeonMaster.UseItem(args);
					
				case "GiveCharacterItem":
                    return this.dungeonMaster.GiveCharacterItem(args);
					
				case "UseItemOn":
                    return this.dungeonMaster.UseItemOn(args);
					
				case "GetStats":
                    return this.dungeonMaster.GetStats();
					
				case "Attack":
                    return this.dungeonMaster.Attack(args);
					
				case "Heal":
                    return this.dungeonMaster.Heal(args);
					
				case "EndTurn":
                    return this.dungeonMaster.EndTurn(args);

                default:
                    return null;
			}
		}
    }
}