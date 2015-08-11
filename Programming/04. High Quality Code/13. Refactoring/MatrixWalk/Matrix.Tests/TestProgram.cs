using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WalkMatrix;

namespace WalkMatrix.Tests
{
    [TestClass]
    public class TestProgram
    {
        [TestMethod]
        public void ExpectProgramToWork()
        {
            var expected = "Enter a positive number \r\n" +
                                "    1   19   20   21   22   23   24\r\n" +
                                "   18    2   33   34   35   36   25\r\n" +
                                "   17   40    3   32   39   37   26\r\n" +
                                "   16   48   41    4   31   38   27\r\n" +
                                "   15   47   49   42    5   30   28\r\n" +
                                "   14   46   45   44   43    6   29\r\n" +
                                "   13   12   11   10    9    8    7\r\n";

            using (StringReader input = new StringReader("7"))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);                    
                   //run Methods for testing.....
                    EntryPoint.Main();

                    Assert.AreEqual(expected, output.ToString());
                }
            }
        }

        [TestMethod]
        public void ExpectProgramToNotAcceptInocrrectInput()
        {
            var expected = "Enter a positive number \r\n" +
                            "You haven't entered a correct positive number\r\n" +
                            "You haven't entered a correct positive number\r\n";

            using (StringReader input = new StringReader("-3\n101\n0\n"))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);                    
                   //run Methods for testing.....
                    EntryPoint.Main();

                    Assert.AreEqual(expected, output.ToString());
                }
            }
        }

        
    }
}
