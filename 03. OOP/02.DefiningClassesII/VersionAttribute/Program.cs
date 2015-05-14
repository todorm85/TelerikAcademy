using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    class VersionAttribute : System.Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public string GetVersion
        {
            get
            {
                return String.Format("{0}.{1}", this.Major, this.Minor);
            }
        }

        public VersionAttribute(int major, int minor)
        {
            if (major < 0 || minor < 0)
            {
                throw new ArgumentException("Version number cannot be negative!");
            }

            this.Major = major;
            this.Minor = minor;
        }

    }

    [Version(1, 11)]
    class Example
    {
        static void Main()
        {
            Type type = typeof(Example);    // type is variable that holds the type Example class
            object[] customAttr = type.GetCustomAttributes(false);  // then we get all custom attributes of variable type, which holds the type of Example
            // then display only the variables of type VersionAttributes that we extracted in our object array
            foreach (VersionAttribute attribute in customAttr)
            {
                Console.WriteLine(attribute.GetVersion);
            }
        }
    }
}