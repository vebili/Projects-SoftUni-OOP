using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMissions> Missions { get; }

        void AddMission(IMissions missions);
    }
}
