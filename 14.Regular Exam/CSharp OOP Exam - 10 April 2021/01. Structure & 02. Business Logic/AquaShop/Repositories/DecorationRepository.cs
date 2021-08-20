using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;

        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.decorations.AsReadOnly();
        //public IReadOnlyCollection<IDecoration> Models { get; private set; }

        public void Add(IDecoration model)
            => this.decorations.Add(model);
        //public void Add(IDecoration model)
        //{
        //    decorations.Add(model);

        //    Models = decorations;
        //}

        public bool Remove(IDecoration model)
            => this.decorations.Remove(model);
        //public bool Remove(IDecoration model)
        //{
        //    if (Models.Contains(model))
        //    {
        //        decorations.Remove(model);

        //        Models = decorations;

        //        return true;
        //    }

        //    return false;
        //}

        public IDecoration FindByType(string type)
            => this.decorations.FirstOrDefault(x => x.GetType().Name == type);
        //public IDecoration FindByType(string type)
        //{
        //    return Models.FirstOrDefault(x => x.GetType().Name == type);
        //}
    }
}
