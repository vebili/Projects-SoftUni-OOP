using System;
using System.Collections.Generic;
using System.Text;

namespace _7.Custom_Exception
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {

        }

        public InvalidPersonNameException(string name, string message)
        : base(name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
