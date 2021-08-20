using System;
using System.Collections.Generic;

namespace _4.PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfNumberIsNotInRange(int min, int max, int number, string exceptionMessage)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
        public static void ThrowIfValueIsNotAllowed(HashSet<string> allowedValues,
            string value,
            string exceptionMeassage)
        {
            if (!allowedValues.Contains(value))
            {
                throw new ArgumentException(exceptionMeassage);
            }
        }
    }
}
