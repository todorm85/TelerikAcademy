using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkMatrix
{
    internal class ConsoleInputProvider
    {
        internal static int GetInput()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n <= 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }
    }
}
