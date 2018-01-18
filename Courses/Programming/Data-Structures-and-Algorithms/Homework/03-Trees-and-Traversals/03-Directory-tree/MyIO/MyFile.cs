namespace MyIO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyFile
    {
        public MyFile(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }

        public long Size { get; set; }
    }
}
