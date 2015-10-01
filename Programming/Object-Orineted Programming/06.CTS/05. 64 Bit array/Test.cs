using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_array64
{
    class Test
    {
        static void Main(string[] args)
        {
            int testNum = 1;
            BitArray64 arr1 = new BitArray64("11");   // all first 62 most significant bit values are assumed 0, only those at indexes 62 and 63 are set to 1
            string returnedVal1 = arr1.BitsArray;
            // check result
            bool testResult = returnedVal1 == "11";
            PrintResult(testNum, testResult);

            testNum = 2;
            BitArray64 arr2 = new BitArray64("11");   
            var returnedVal2 = arr2[63];
            testResult = returnedVal2 == (byte)1;
            PrintResult(testNum, testResult);

            testNum = 3;
            BitArray64 arr3 = new BitArray64("11");   
            var returnedVal3 = arr3[61];
            testResult = returnedVal3 == (byte)0;
            PrintResult(testNum, testResult);

            // next we set to 1 the two most significant bits at indexes 0 and 1
            BitArray64 arr4 = new BitArray64("11" + new string('0',62));

            testNum = 4;
            var returnedVal4 = arr4[1];
            testResult = returnedVal4 == (byte)1;
            PrintResult(testNum, testResult);

            testNum = 5;
            returnedVal4 = arr4[3];
            testResult = returnedVal4 == (byte)0;
            PrintResult(testNum, testResult);

            testNum = 6;
            arr4[3] = 1;
            returnedVal4 = arr4[3];
            testResult = returnedVal4 == (byte)1;
            PrintResult(testNum, testResult);

            testNum = 7;
            BitArray64 arr7 = new BitArray64("11");
            BitArray64 arr7_copy = new BitArray64("11");
            testResult = arr7 == arr7_copy;
            PrintResult(testNum, testResult);

            testNum = 8;
            testResult = !(arr7 != arr7_copy);
            PrintResult(testNum, testResult);

            testNum = 9;
            testResult = arr7.Equals( arr7_copy);
            PrintResult(testNum, testResult);

            testNum = 10;
            testResult = !arr7.Equals(null);
            PrintResult(testNum, testResult);
            testResult = !(arr7 == null);
            PrintResult(testNum, testResult);
            testResult = !(null == arr7);
            PrintResult(testNum, testResult);
            testResult = (arr7_copy == arr7);
            PrintResult(testNum, testResult);

            testNum = 11;
            StringBuilder sb = new StringBuilder();
            foreach (var bit in arr7)
            {
                sb.Append(bit);
            }

            testResult = sb.ToString() == arr7.BitsArray.PadLeft(64,'0');
            PrintResult(testNum, testResult);
        }

        static void PrintResult(int test, bool result, string message = "")
        {
            var delimiter = new String('-', 50);
            Console.WriteLine("{0}\nTest {1} passed: {2}{3}", delimiter, test, result, "\n" + message);
        }
    }
}
