using System;
using System.Linq;

namespace Telephony
{
    public class SmartPhone : ICallable ,IBrowsable
    {
        public string Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }
    }
}