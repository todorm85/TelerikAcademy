using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// good article
// http://www.codeproject.com/Articles/18714/Comparing-Values-for-Equality-in-NET-Identity-and
/* == by default calls ReferenceEquals(),
 * Equals() by default calls RefrenceEquals() for reference types, for value types compares their values
 * Equals() is overriden for string type to compare by value, not reference!
 * GetHashCode() for all system classes it returns a unique int thatrepresents current instance, we should redefine it to return aunique result of hashcodes of our instance members, we canXOR their hashcodes for example
 * ReferenceEquals() for value types will always return false
 * strings behave like value types, although they actually store addresses in stack
*/
namespace _01.Comparison
{
    struct Coord
    {
        int x;
        int y;
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string delim = new string('-', 50);

            string st1 = "Niki";
            string st2 = "Niki";
            string st3 = st2;
            st3 = "Gosho";
            Console.WriteLine(Object.ReferenceEquals(st3, st2));  // returns false, because for strings assigning new value doesn`t change the value in heap, but creates  new instance, writes the new value there and changes the address of the string to point to the new address with the new value. st2 value is unchanged

            //st3 = Console.ReadLine();

            Console.WriteLine(st3.Equals(st2)); // if we entered "Niki" at the console this will return true, because Equals is overriden for string types to compare by value
            Console.WriteLine(Object.ReferenceEquals(st3, st2)); // this will return false because st3 has different address than st2, although its value is the same it was dynamically (at runtime) assigned, so it was stored in a new address in heap. If it was compile time aassigned, it was going to be at the same address as st2, so this would have returned true

            Console.WriteLine(delim);
            int i1 = 1;
            //int i2 = int.Parse(Console.ReadLine());
            int i2 = 1;
            Console.WriteLine(ReferenceEquals(i1, i2));
            Console.WriteLine(Equals(i1, i2));
            Console.WriteLine(i1 == i2);

            Console.WriteLine(delim);
            Coord c1 = new Coord(1, 2);
            Coord c2 = new Coord(1, 2);

            Console.WriteLine(ReferenceEquals(c1, c2)); // always gives false for value types
            Console.WriteLine(Equals(c1, c2)); // actually compares them
            //Console.WriteLine(c1 == c2); // must be overriden first
        }
    }
}
