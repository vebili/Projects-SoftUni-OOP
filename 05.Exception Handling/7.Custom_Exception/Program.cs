using System;
using System.Collections.Generic;

namespace _7.Custom_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            try
            {
                throw new InvalidPersonNameException("Gin4o", "It is not found");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine($"{ex.Name} -> {ex.Message}");
            }
            catch (SystemException se)
            {
                Console.WriteLine(se.Message);
            }
    }
    }
}
