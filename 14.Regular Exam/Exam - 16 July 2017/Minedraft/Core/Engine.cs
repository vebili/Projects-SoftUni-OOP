
using System;
using System.Linq;
using System.Text;

public class Engine
    {
        private DraftManager manager;

        public Engine()
        {
            this.manager = new DraftManager();
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                StringBuilder result = new StringBuilder();
                try
                {
                    switch (command[0])
                    {
                        case "RegisterHarvester":
                            result.AppendLine(this.manager.RegisterHarvester(command.Skip(1).ToList()));
                            break;

                        case "RegisterProvider":
                            result.AppendLine(this.manager.RegisterProvider(command.Skip(1).ToList()));
                            break;

                        case "Day":
                            result.AppendLine(this.manager.Day());
                            break;

                        case "Mode":
                            result.AppendLine(this.manager.Mode(command.Skip(1).ToList()));
                            break;

                        case "Check":
                            result.AppendLine(this.manager.Check(command.Skip(1).ToList()));
                            break;

                        case "Shutdown":
                            result.AppendLine(this.manager.ShutDown());
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    result.AppendLine(e.Message);
                    
                }

                Console.WriteLine(result.ToString().TrimEnd());
            }
        }
    }

