using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School_classes
{
    public class Discipline : SchoolObject
    {
        private string name;
        private int excersizesCount;
        private int lecturesCount;

        public Discipline(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Empty name not allowed!");
            }

            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int LecturesCount
        {
            get { return this.lecturesCount; }
            set { this.lecturesCount = value; }
        }

        public int ExcersizesCount
        {
            get { return this.excersizesCount; }
            set { this.excersizesCount = value; }
        }
    }
}
