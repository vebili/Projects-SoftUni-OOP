using System;

namespace _3.Shopping_Spree
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str, string exeptionMessage)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exeptionMessage);
            }
        }

        public static void ThrowIfNumberIsNegative(decimal number, string exeptionMessage)
        {
            if (number <0)
            {
                throw new ArgumentException(exeptionMessage);
            }
        }
    }
}
