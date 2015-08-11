using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WalkMatrix;

namespace WalkMatrix.Tests
{
    [TestClass]
    public class TestMatrixGenerator
    {
        [TestMethod]
        public void MatrixGeneratorGetNextDirectionShouldSwitchDirectionCorrectly()
        {
            int currentDirRow = 0;
            int currentDirCol = 1;

            MatrixGenerator.GetNextDirection(ref currentDirRow, ref currentDirCol);
            Assert.AreEqual(1, currentDirRow);
            Assert.AreEqual(1, currentDirCol);

            MatrixGenerator.GetNextDirection(ref currentDirRow, ref currentDirCol);
            Assert.AreEqual(1, currentDirRow);
            Assert.AreEqual(0, currentDirCol);
        }
    }
}
