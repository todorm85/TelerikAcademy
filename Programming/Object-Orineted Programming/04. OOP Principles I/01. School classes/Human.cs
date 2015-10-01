using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School_classes
{
    public abstract class Human : SchoolObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
