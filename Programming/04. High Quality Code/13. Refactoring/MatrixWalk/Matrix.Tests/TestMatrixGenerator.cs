using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WalkMatrix.MatrixGenerator;

namespace WalkMatrix.Tests
{
    [TestClass]
    public class TestMatrixGenerator
    {
        [TestMethod]
        public void MatrixGeneratorGetNextDirectionShouldSwitchDirectionCorrectly()
        {
            Direction dir = Direction.DownRight;

            for (int i = 0; i < 7; i++)
            {                
                dir = Generator.GetNextDirection(dir);
            }

            Assert.AreEqual(Direction.Right, dir);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellExists()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,0,1,1,1}
                         };
            var position = new Position(0, 0);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

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
            var position = new Position(2, 1);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

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
            var position = new Position(2, 3);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

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
            var position = new Position(0, 4);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

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

            var position = Generator.FindFirstFreeCellPosition(matrix);

            Assert.AreEqual(1, position.Row);
            Assert.AreEqual(1, position.Col);
        }

        [TestMethod]
        public void MatrixGeneratorFindFirstFreeCellShouldWorkWhenFreeCellDoesNotExist()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1}
                         };

            var position = Generator.FindFirstFreeCellPosition(matrix);

            Assert.AreEqual(null, position);
        }

        [TestMethod]
        public void IsPositionValidShouldReturnTrueOnValidPosition()
        {
            var matrix = new int[,] {
                {1,1,1,1,0},
                {1,1,1,1,1},
                {1,1,1,0,0}
                         };

            var position = new Position(0, 4);
            Assert.IsTrue(Generator.IsPositionValid(matrix, position), "0 4");
            position = new Position(2, 4);
            Assert.IsTrue(Generator.IsPositionValid(matrix, position), "2 4");
            position = new Position(2, 3);
            Assert.IsTrue(Generator.IsPositionValid(matrix, position), "2 3");
        }

        [TestMethod]
        public void IsPositionValidShouldReturnFalseOnInvalidPosition()
        {
            var matrix = new int[,] {
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1}
                         };

            var position = new Position(2, 4);
            Assert.IsFalse(Generator.IsPositionValid(matrix, position));
            position = new Position(2, -5);
            Assert.IsFalse(Generator.IsPositionValid(matrix, position));
            position = new Position(-1, 3);
            Assert.IsFalse(Generator.IsPositionValid(matrix, position));
        }
    }
}
