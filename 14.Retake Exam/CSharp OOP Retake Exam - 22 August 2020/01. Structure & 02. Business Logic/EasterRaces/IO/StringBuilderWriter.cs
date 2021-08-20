using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.IO.Contracts;

namespace EasterRaces.IO
{
    class StringBuilderWriter:IWriter
    {
        private StringBuilder sb;

        public StringBuilderWriter()
        {
            sb = new StringBuilder();
        }

        public void WriteLine(string message)
        {
            this.sb.AppendLine(message);
        }

        public void Write(string message)
        {
            this.sb.Append(message);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
