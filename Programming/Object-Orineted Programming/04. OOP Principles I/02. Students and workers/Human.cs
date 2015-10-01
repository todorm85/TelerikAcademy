using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_and_workers
{
    abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Human(string first, string last)
        {
            if (String.IsNullOrEmpty(first) || String.IsNullOrEmpty(last))
            {
                throw new ArgumentException("Empty entries are invalid");
            }

            this.FirstName = first;
            this.LastName = last;
        }
    }
}
