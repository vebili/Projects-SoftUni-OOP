namespace ViceCity.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Guns.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> models;

        public GunRepository()
        {
            models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.models.AsReadOnly();
        public void Add(IGun model)
        {
            if (this.Models.All(g => g.Name != model.Name))
            {
                this.models.Add(model);
            }
        }

        public bool Remove(IGun model)
        {
            return this.models.Remove(model);
        }

        public IGun Find(string name)
        {
            return this.models.FirstOrDefault(g => g.Name == name);
        }
    }
}