using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_and_workers
{
    class Worker : Human
    {
        // Fields
        private double weekSalary;
        private double workHoursPerDay;

        // Properties
        public double WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value<0 || value > 24)
                {
                    throw new ArgumentException("Invalid daily workhours value!");
                } 

                workHoursPerDay = value; }
        }

        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Invalid salary value! Cannot be negative!");
                }

                this.weekSalary = value;
            }
        }

        // Constructors
        public Worker(string first, string last, double salary, double workHours)
            : this (first, last)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHours;
        }

        public Worker(string first, string last)
            : base(first, last) 
        { }

        // Mehods
        public double MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, Money/hour: {2}", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
