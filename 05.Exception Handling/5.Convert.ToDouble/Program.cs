using System;

namespace _5.Convert_ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double num = Convert.ToDouble(Console.ReadLine());
                throw new FormatException();
                throw new InvalidCastException();
                throw new OverflowException();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            //try
            //{
            //    try
            //    {
            //        try
            //        {
            //            double num = Convert.ToDouble(Console.ReadLine());
            //            throw new InvalidCastException();

            //        }
            //        catch (InvalidCastException ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //        }

            //        throw new OverflowException();

            //    }
            //    catch (OverflowException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //    throw new FormatException();

            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.ReadLine();
        }
    }
}
