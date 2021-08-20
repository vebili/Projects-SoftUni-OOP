using System;

namespace EasterRaces.Utilities
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullEmptyOrLessThan(string str, int minLen, string message)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < minLen)
            {
                throw new ArgumentException(message);
            }

        }
    }
}
