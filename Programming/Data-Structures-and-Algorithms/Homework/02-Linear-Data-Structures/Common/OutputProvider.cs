using System;
using System.IO;

namespace Common
{
    public class OutputProvider
    {
        private TextWriter outputStream;

        public OutputProvider(TextWriter outputStream)
        {
            this.outputStream = outputStream;
        }

        public void WriteLine(string line)
        {
            this.outputStream.WriteLine(line);
        }
    }
}