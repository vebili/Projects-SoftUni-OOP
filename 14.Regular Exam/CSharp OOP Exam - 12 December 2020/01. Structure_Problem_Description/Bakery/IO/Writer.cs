﻿namespace Bakery.IO
{
    using Bakery.IO.Contracts;
    using System;
    using System.IO;

    public class Writer : IWriter
    {
        string path = "../../../result.txt";

        public Writer()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write("");
            }
        }

        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
