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
            int currentDirRow = -1;
            int currentDirCol = -1;

            for (int i = 0; i < 8; i++)
            {                
                MatrixGenerator.GetNextDirection(ref currentDirRow, ref currentDirCol);
            }

            Assert.AreEqual(1, currentDirRow);
            Assert.AreEqual(1, currentDirCol);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellExists()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,0,1,1,1}
                         };

            var cellExist = MatrixGenerator.CheckIfFreeNeighbourCellExists(matrix, 1, 1);

            Assert.IsTrue(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellExistsAndPositionIsAtTheBorderOfMatrix()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,0,1,1,1}
                         };

            var cellExist = MatrixGenerator.CheckIfFreeNeighbourCellExists(matrix, 0, 0);

            Assert.IsTrue(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellDeosNotExists()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,1,1,1,1}
                         };

            var cellExist = MatrixGenerator.CheckIfFreeNeighbourCellExists(matrix, 1, 1);

            Assert.IsFalse(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellDeosNotExistsAndPositionIsAtTheBorder()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,1,1,1,1}
                         };

            var cellExist = MatrixGenerator.CheckIfFreeNeighbourCellExists(matrix, 0, 4);

            Assert.IsFalse(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorFindFirstFreeCellShouldWorkWhenFreeCellExists()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,1,0,1,1}
                         };
            int row = 0;
            int col = 0;

            MatrixGenerator.FindFirstFreeCell(matrix, ref row, ref col);

            Assert.AreEqual(1, row);
            Assert.AreEqual(1, col);
        }

        [TestMethod]
        public void MatrixGeneratorFindFirstFreeCellShouldWorkWhenFreeCellDoesNotExist()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1}
                         };
            int row = 0;
            int col = 0;

            MatrixGenerator.FindFirstFreeCell(matrix, ref row, ref col);

            Assert.AreEqual(-1, row);
            Assert.AreEqual(-1, col);
        }
    }
}
