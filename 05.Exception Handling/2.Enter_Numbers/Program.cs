using System;

namespace _2.Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            ReadNumber(start, end);
        }

        static void ReadNumber(int start, int end)
        {
            int count = 0;
            int prevNum = 0;

            while (count < 10)
            {
                int n = int.Parse(Console.ReadLine());

                try
                {
                    if (n < start || n > end)
                    {
                        throw new Exception("Number is not in range, start again");
                    }

                    if (n <= prevNum)
                    {
                        throw new Exception("Number is smaller from previous number, start again");
                    }

                    prevNum = n;
                    count++;
                    Console.WriteLine($"{n} {count}");
                }
                catch (Exception ex)
                {
                    prevNum = 0;
                    count = 0;
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
