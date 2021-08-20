namespace MortalEngines.Core
{
    using System;
    using System.Text;
    using Contracts;

    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Quit")
                {
                    break;
                }

                StringBuilder result = new StringBuilder();

                string command = input[0];
                string name = input[1];

                try
                {
                    switch (command)
                    {
                        case "HirePilot":
                            {
                                result.AppendLine(this.machinesManager.HirePilot(name));
                            }
                            break;

                        case "PilotReport":
                            {
                                result.AppendLine(this.machinesManager.PilotReport(name));
                            }
                            break;

                        case "ManufactureTank":
                            {
                                double attack = double.Parse(input[2]);
                                double defense = double.Parse(input[3]);

                                result.AppendLine(this.machinesManager.ManufactureTank(name, attack, defense));
                            }
                            break;

                        case "ManufactureFighter":
                            {
                                double attack = double.Parse(input[2]);
                                double defense = double.Parse(input[3]);

                                result.AppendLine(this.machinesManager.ManufactureFighter(name, attack, defense));
                            }
                            break;

                        case "MachineReport":
                            {
                                result.AppendLine(this.machinesManager.MachineReport(name));
                            }
                            break;

                        case "AggressiveMode":
                            {
                                result.AppendLine(this.machinesManager.ToggleFighterAggressiveMode(name));
                            }
                            break;

                        case "DefenseMode":
                            {
                                result.AppendLine(this.machinesManager.ToggleTankDefenseMode(name));
                            }
                            break;

                        case "Engage":
                            {
                                string pilotName = name;
                                string machineName = input[2];

                                result.AppendLine(this.machinesManager.EngageMachine(pilotName, machineName));
                            }
                            break;

                        case "Attack":
                            {
                                string attackingMachineName = name;
                                string defendingMachineName = input[2];

                                result.AppendLine(this.machinesManager.AttackMachines(attackingMachineName, defendingMachineName));
                            }
                            break;

                        default: break;
                    }
                }
                catch (ArgumentNullException ane)
                {
                    result.AppendLine("Error: " + ane.Message);
                }
                catch (NullReferenceException nre)
                {
                    result.AppendLine("Error: " + nre.Message);
                }

                Console.WriteLine(result.ToString().TrimEnd());
            }
        }
    }
}