using System;
using System.Collections.Generic;

namespace _6.Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            try
            {
                people.Add(new Person("Stefa", "Petrov", 37));

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                people.Add(new Person(string.Empty, "Petrov", 37));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                people.Add(new Person("Stefa", String.Empty, 37));

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                people.Add(new Person("Stefa", "Petrov", -1));

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                people.Add(new Person("Stefa", "Petrov", 122));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
