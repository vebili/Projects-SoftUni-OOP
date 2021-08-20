using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public void Add(string el)
        {
            base.Add(el);
            Console.WriteLine($"Added the string {el} and we have custom functianalities");
        }

        public string RandomString()
        {
            if (Count == 0)
            {
                return null;
            }
            return this[random.Next(0, this.Count)];
        }
    }
}
