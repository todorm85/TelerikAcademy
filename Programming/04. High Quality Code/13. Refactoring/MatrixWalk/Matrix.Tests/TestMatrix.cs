using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Matrix;

namespace Matrix.Tests
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void MatrixWalkShouldWorkWithValidInput()
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
                    MatrixWalk.Main();

                    Assert.AreEqual(expected, output.ToString());
                }
            }
        }

        [TestMethod]
        public void MatrixWalkShouldNotAcceptInvalidInput()
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
                    MatrixWalk.Main();

                    Assert.AreEqual(expected, output.ToString());
                }
            }
        }

        [TestMethod]
        public void ChangeDirectionClockwiseShouldSwitchDirectionCorrectly()
        {
            int currentDirRow = 0;
            int currentDirCol = 1;

            MatrixWalk.ChangeDirectionClockwise(ref currentDirRow, ref currentDirCol);
            Assert.AreEqual(1, currentDirRow);
            Assert.AreEqual(1, currentDirCol);

            MatrixWalk.ChangeDirectionClockwise(ref currentDirRow, ref currentDirCol);
            Assert.AreEqual(1, currentDirRow);
            Assert.AreEqual(0, currentDirCol);
        }
    }
}
