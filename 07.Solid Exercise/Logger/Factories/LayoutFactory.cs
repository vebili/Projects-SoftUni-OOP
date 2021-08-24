using System;

using Logger.Models.Layouts;
using Logger.Models.Contracts;
using System.Reflection;
using System.Linq;

namespace Logger.Factories
{
   public class LayoutFactory
    {

        public ILayout ProduceLayout(string layoutType)
        {
            
            Assembly assemby = Assembly.GetExecutingAssembly();
            Type type = assemby
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == layoutType.ToLower());

            object[] args = new object[] { };

            ILayout layout = (ILayout)Activator.CreateInstance(type, args);

            return layout;
        }
    }
}