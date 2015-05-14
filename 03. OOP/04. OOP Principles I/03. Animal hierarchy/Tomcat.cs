using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Animal_hierarchy
{
    class Tomcat : Cat
    {
        public Tomcat()
            : base("Unnamed tomcat","m",0)
        { }

        public Tomcat(string name, int age)
            :base(name,"m",age)
        { }

        public override string Sex
        {
            get
            {
                return base.Sex;
            }
            set
            {
                if (value!="m")
                {
                    throw new ArgumentException("Tomcats can only be male \'m\'!");
                }

                base.Sex = value;
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Tomcat {0} said \"MIAAAAAAAAAAAUUUUUUUUUU!\"!",this.Name);
        }
    }
}
