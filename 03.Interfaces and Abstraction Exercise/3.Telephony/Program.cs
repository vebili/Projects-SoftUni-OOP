using System;
using System.ComponentModel.Design;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            SmartPhone smartPhone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                try
                {
                    string result = number.Length == 10
                        ? smartPhone.Call(number) :
                        stationaryPhone.Call(number);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    string result = smartPhone.Browse(url);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
