using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_hierarchy
{
    public abstract class Animal : ISound
    {
        private string sex;
        private string name;

        protected Animal ()
        {
            this.Name = "Unnamed animal";
            this.Age = 0;
            this.Sex = "?";
        }

        protected Animal(string name, string sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty entries are not allowed!");
                }

                name = value;
            }
        }

        public int Age { get; set; }

        public virtual string Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                if (value != "m" && value != "f" && value!="?")
                {
                    throw new ArgumentException("Gender must be \"m\" or \"f\" or \"?\"!");
                }

                this.sex = value;
            }
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("{0} made a strange animalistic sound!", this.Name);
        }
    }
}
