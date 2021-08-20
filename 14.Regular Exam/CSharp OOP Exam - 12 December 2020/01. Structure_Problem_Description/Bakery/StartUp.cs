using System;
using System.Globalization;
using System.Threading;
using Bakery.Models.BakedFoods;
using Bakery.Models.Tables;

namespace Bakery
{
    using Bakery.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            //InsideTable table = new InsideTable(5, 45);
            //Bread bread = new Bread("lebec", 5);
            //table.OrderFood(bread);
            //Console.WriteLine(table.GetFreeTableInfo());
            //Console.WriteLine(table.GetBill());

            //Don't forget to comment out the commented code lines in the Engine class!
            var engine = new Engine();

            engine.Run();
        }
    }
}
