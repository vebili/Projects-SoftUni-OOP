
public class HammerHarvester : Harvester
    {
        public HammerHarvester(string id, double oreOutput, double energyRequirement)
            : base(id, 3 * oreOutput, 2 * energyRequirement)
        {
        }
    }

