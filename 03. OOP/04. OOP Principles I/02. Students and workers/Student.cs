using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_and_workers
{
    class Student : Human
    {
        // Fields
        private double grade;

        // Properties
        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value<2||value>6)
                {
                    throw new ArgumentException("Invalid grade value!");
                }

                this.grade = value;
            }
        }

        // Constructors
        public Student(string first, string last, double grade)
            : this (first, last)
        {
            this.Grade = grade;
        }

        public Student(string first, string last)
            : base(first, last) 
        { }

        public override string ToString()
        {
            return String.Format("{0} {1}, Grade: {2}",this.FirstName, this.LastName, this.Grade);
        }
    }
}
