using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Longest_string
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringArray = new[] { "sfdsf", "tetfik", "yabadabaduuuu" };
            var result =
                from str in stringArray
                orderby str.Length descending
                select str;
            Console.WriteLine("Longest string is: {0}", result.ToArray()[0]);
        }
    }
}
