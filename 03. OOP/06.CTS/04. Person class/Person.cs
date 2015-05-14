using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_class
{
    class Person
    {
        byte? age;
        string name;

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public byte? Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {            
            return String.Format("{0}, age: {1}", this.Name, (this.Age==null)?"No":this.Age.ToString());
        }
    }
}
