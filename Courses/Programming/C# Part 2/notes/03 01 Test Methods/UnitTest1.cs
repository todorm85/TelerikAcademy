using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_01_Test_Methods
{
    [TestClass]
    public class UnitTest1
    {
        // first add reference to 03 00 Methods!!!!!
        // the methods to test in 03 00 must be public!!!!!
        // right click here to RunTest
        [TestMethod]
        public void TestCalcSum1and2()
        {
            long res = MethodsLecture.LectureNotes.CalcSum(1, 2);
            Assert.AreEqual(3, res);
        }

        [TestMethod]
        public void TestCalcSumZero()
        {
            long res = MethodsLecture.LectureNotes.CalcSum();
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void TestCalcSumIntMax()
        {
            long res = MethodsLecture.LectureNotes.CalcSum(int.MaxValue, int.MaxValue);
            Assert.AreEqual(int.MaxValue + (long)int.MaxValue, res);
        }
    }
}
