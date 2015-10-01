using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School_classes
{
    public class Student : Human
    {
        private static int lastID = 1;
        private int classNumber;

        public Student(string name)
        {
            this.Name = name;
            this.ClassNumber = lastID;
            lastID++;
        }

        public int ClassNumber
        {
            get { return classNumber; }
            private set { classNumber = value; }
        }
    }
}
