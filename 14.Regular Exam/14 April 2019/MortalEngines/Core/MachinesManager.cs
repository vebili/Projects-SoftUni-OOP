namespace MortalEngines.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    
    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            if (this.pilots.All(p => p.Name != name))
            {
                IPilot pilotToAdd = new Pilot(name);

                this.pilots.Add(pilotToAdd);

                return string.Format(OutputMessages.PilotHired, pilotToAdd.Name);
            }

            return string.Format(OutputMessages.PilotExists, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.All(m => m.Name != name))
            {
                Tank tankToAdd = new Tank( name, attackPoints, defensePoints);

                this.machines.Add(tankToAdd);

                return string.Format(OutputMessages.TankManufactured, tankToAdd.Name, tankToAdd.AttackPoints, tankToAdd.DefensePoints);
            }

            return string.Format(OutputMessages.MachineExists, name);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.All(m => m.Name != name))
            {
                Fighter fighterToAdd = new Fighter( name, attackPoints, defensePoints);

                this.machines.Add(fighterToAdd);

                return string.Format(OutputMessages.FighterManufactured, fighterToAdd.Name, fighterToAdd.AttackPoints, fighterToAdd.DefensePoints, fighterToAdd.AggressiveModeString);
            }

            return string.Format(OutputMessages.MachineExists, name);
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilotToFind = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            bool isPilotExists = pilotToFind != null;

            IMachine machineToFind = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);
            bool isMachineExists = machineToFind != null;

            bool isMachineFree = machineToFind?.Pilot == null;

            if (!isPilotExists)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (!isMachineExists)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (!isMachineFree)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            machineToFind.Pilot = pilotToFind;
            return string.Format(OutputMessages.MachineEngaged, pilotToFind.Name, machineToFind.Name);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine machineToAttack = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            bool isAttackingMachineExists = machineToAttack != null;

            IMachine machineToDefend = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);
            bool isDefendingMachineExists = machineToDefend != null;

            bool isAttackingDead = machineToAttack?.HealthPoints == 0.0;

            bool isDefendingDead = machineToDefend?.HealthPoints == 0.0;

            if (!isAttackingMachineExists)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (!isDefendingMachineExists)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (isAttackingDead)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if (isDefendingDead)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            machineToAttack.Attack(machineToDefend);

            return string.Format(OutputMessages.AttackSuccessful, machineToDefend.Name, machineToAttack.Name, machineToDefend.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilotToReport = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            return pilotToReport.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machineToReport = this.machines.FirstOrDefault(m => m.Name == machineName);

            return machineToReport.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter fighterToToggle = (IFighter)this.machines.FirstOrDefault(t => t.Name == fighterName);

            if (fighterToToggle == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighterToToggle.ToggleAggressiveMode();
            return string.Format(OutputMessages.FighterOperationSuccessful, fighterToToggle.Name);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank tankToToggle = (ITank)this.machines.FirstOrDefault(t => t.Name == tankName);

            if (tankToToggle == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tankToToggle.ToggleDefenseMode();
            return string.Format(OutputMessages.TankOperationSuccessful, tankToToggle.Name);
        }
    }
}