using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalkMatrix.MatrixGenerator;

namespace WalkMatrix.Tests
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void MatrixConstructorShouldCreateValidMatrix()
        {
            Matrix matrix = new Matrix(3, 3);
            var pos = new Position(2, 2);
            matrix[pos] = 5;

            Assert.AreEqual(5, matrix[pos]);
            Assert.AreEqual(0, matrix[new Position(2, 1)]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void MatrixShouldThrowOnInvalidIndexer()
        {
            Matrix matrix = new Matrix(3, 3);
            matrix[new Position(5, 5)] = 4;
        }
    }
}
