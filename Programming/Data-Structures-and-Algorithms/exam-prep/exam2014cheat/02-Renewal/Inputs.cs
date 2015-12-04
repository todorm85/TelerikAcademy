using System;
using System.IO;

namespace Renewal
{
    internal class Inputs
    {
        public const string Test1 = @"3
000
000
000
ABD
BAC
DCA
ABD
BAC
DCA";

        public const string Test2 = @"3
011
101
110
ABD
BAC
DCA
ABD
BAC
DCA";

        public const string Test3 = @"6
011000
101000
110000
000011
000101
000110
ABDFFF
BACFFF
DCAFFF
FFFABD
FFFBAC
FFFDCA
ABDFFF
BACFFF
DCAFFF
FFFABD
FFFBAC
FFFDCA";

        internal static void SetInput(string testNum)
        {
            var ar = new StreamReader(File.Open($@"..\..\tests\test.{testNum}.out.txt", FileMode.Open));
            Console.WriteLine($"Expected: {ar.ReadLine()}");
            var tr = new StreamReader(File.Open($@"..\..\tests\test.{testNum}.in.txt", FileMode.Open));

            //var tr = new StringReader(testNum);

            Console.SetIn(tr);
        }
    }
}