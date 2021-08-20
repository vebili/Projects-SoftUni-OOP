
    public class PressureProvider : Provider
    {
        public PressureProvider(string id, double energyOutput)
            : base(id, 1.5 * energyOutput)
        {
        }
    }
