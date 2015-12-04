using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsHw
{
    static class Inputs
    {
        public static void SetInput(int num)
        {
            var outputReader = new StreamReader($@"..\..\tests\test.00{num}.out.txt");
            Console.WriteLine(outputReader.ReadLine());

            var inputReader = new StreamReader($@"..\..\tests\test.00{num}.in.txt");
            Console.SetIn(inputReader);
        }
    }
}
