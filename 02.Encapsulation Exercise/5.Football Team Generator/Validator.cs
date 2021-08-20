using System;

namespace _5.FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string str, string exceptionMessage)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfNumberIsNotInrange(int number, int min, int max, string exceptionMessage)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
