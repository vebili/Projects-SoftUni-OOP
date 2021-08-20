using System;
using System.Linq;

namespace Telephony
{
    public static class Validator
    {
        public static void ThrowIfNumberIsInvalid(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }
    }
}
