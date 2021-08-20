using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly IDictionary<string, ICar> carByModel;

        public CarRepository()
        {
            carByModel = new Dictionary<string, ICar>();
        }

        public ICar GetByName(string name)
        {
            return this.carByModel.GetByKeyOrDefault(name);

            //ICar car = null;
            //if (this.carByModel.ContainsKey(name))
            //{
            //    car = this.carByModel[name];
            //}

            //return car;
        }

        public IReadOnlyCollection<ICar> GetAll() => this.carByModel.Values.ToList();

        public void Add(ICar model)
        {
            if (this.carByModel.ContainsKey(model.Model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model.Model));
            }

            this.carByModel.Add(model.Model, model);
        }

        public bool Remove(ICar model) => this.carByModel.Remove(model.Model);
    }
}
