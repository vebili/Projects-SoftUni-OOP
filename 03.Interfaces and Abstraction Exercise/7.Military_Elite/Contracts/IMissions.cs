using MilitaryElite.Enums;

namespace MilitaryElite.Contracts
{
    public interface IMissions
    {
        string CodeName { get; }

        MissionState MissionState { get; }

        void CompleteMission();
    }
}
