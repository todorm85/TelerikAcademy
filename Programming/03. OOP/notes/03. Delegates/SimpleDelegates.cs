using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// delegates are type of variable that describes Methods
// they are types of Methods like integer are types of whole numbers
// delegates are variables of type "method description"
// like integerss are variables of type "integer number description"
// since delegates are types of data (they describe objects)
// they are equal to classes and structures and are defined after the namespace
// they can be inside another class, they can be internal, but can`t be private

namespace SampleDelegates
{
    public delegate void TestDelegate(string input);
    public delegate T TestDelegate<T>(T param);
    public delegate int GenericMulticast<T>(T param);

    public class Methods
    {
        public int InstanceMethodInt(string param)
        {
            Console.WriteLine("I am InstanceMethodInt with param `{0}`", param);
            return 1;
        }

        public static int StaticMethodInt(string param)
        {
            Console.WriteLine("I am StaticMethodInt with param `{0}`", param);
            return 2;
        }

        public static void TestString1(string param)
        {
            Console.WriteLine("I am TestString1, I was called with parameter {0}", param);
        }

        public static void TestString2(string param)
        {
            Console.WriteLine("I am TestString2, I was called with parameter {0}", param);
        }

        public static void TestInt1(int input)
        {
            Console.WriteLine("I am TestInt1, called with param {0}", input);
        }

        public static void TestInt2(int input)
        {
            Console.WriteLine("I am TestInt2, called with param {0}", input);
        }

        public static int TestInt1Return(int input)
        {
            Console.WriteLine("I am TestInt1, called with param {0}", input);
            return 0;
        }

        public static int TestInt2Return(int input)
        {
            Console.WriteLine("I am TestInt2, called with param {0}", input);
            return 0;
        }
    }

    class Program
    {     
        static void Main(string[] args)
        {
            string delimiter = new string('-', 50);

            //TestDelegate testDelegate = new TestDelegate(TestMethod);
            TestDelegate testDelegate = Methods.TestString1;
            testDelegate("test1");

            Console.WriteLine(delimiter);

            testDelegate += Methods.TestString2;
            testDelegate("test2");

            Console.WriteLine(delimiter);

            TestDelegate<int> genericDelegate = new TestDelegate<int>(Methods.TestInt1Return);
            genericDelegate(15);

            Console.WriteLine(delimiter);

            genericDelegate += Methods.TestInt2Return;
            genericDelegate(25);

            Console.WriteLine(delimiter);

            // ANONYMOUS METHODS
            TestDelegate anonymousDelegate = delegate(string str)
            {
                Console.WriteLine("I am anonymous method with parameter \"{0}\".", str);
            };

            anonymousDelegate("anonymous test");

            Console.WriteLine(delimiter);

            // Multicast Generic Delegate
            // we assign a Static and Instance methods to delegate
            GenericMulticast<string> staticInstanceDelegate = Methods.StaticMethodInt;
            // next we create a new instance of class Methods with default constructor
            // and call instance method InstanceMethodInt() on this new unnamed instance
            // and assign it to delegate staticInstanceDelegate
            // the returned value is the one from the last executed method
            staticInstanceDelegate += new Methods().InstanceMethodInt;
            int staticInstanceReturn = staticInstanceDelegate("testing static and instance delegate");
            Console.WriteLine(staticInstanceReturn);

            Console.WriteLine(delimiter);

            staticInstanceDelegate += delegate(string str)
            {
                Console.WriteLine("Anonymous method called with param: {0}", str);
                return 3;
            };
            
            staticInstanceReturn = staticInstanceDelegate("testing static and instance delegate");
            Console.WriteLine(staticInstanceReturn);
        }
    }
}
