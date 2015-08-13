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
            var arr = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,0,1,1,1}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
            var position = new Position(0, 0);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

            Assert.IsTrue(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellExistsAndPositionIsAtTheBorderOfMatrix()
        {
            var arr = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,0,1,1,1}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
            var position = new Position(2, 1);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

            Assert.IsTrue(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellDeosNotExists()
        {
            var arr = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,1,1,1,1}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
            var position = new Position(2, 3);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

            Assert.IsFalse(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorCheckIfFreeNeighbourCellExistsShouldWorkIfFreeNeighbourCellDeosNotExistsAndPositionIsAtTheBorder()
        {
            var arr = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,1,1,1,1}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
            var position = new Position(0, 4);

            var cellExist = Generator.CheckIfFreeNeighbourCellExists(matrix, position);

            Assert.IsFalse(cellExist);
        }

        [TestMethod]
        public void MatrixGeneratorFindFirstFreeCellShouldWorkWhenFreeCellExists()
        {
            var arr = new int[,] {
                {1,1,1,1,1},
                {1,0,1,1,1},
                {1,1,0,1,1}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
            var position = Generator.FindFirstFreeCellPosition(matrix);

            Assert.AreEqual(1, position.Row);
            Assert.AreEqual(1, position.Col);
        }

        [TestMethod]
        public void MatrixGeneratorFindFirstFreeCellShouldWorkWhenFreeCellDoesNotExist()
        {
            var arr = new int[,] {
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
            var position = Generator.FindFirstFreeCellPosition(matrix);

            Assert.AreEqual(null, position);
        }

        [TestMethod]
        public void IsPositionValidShouldReturnTrueOnValidPosition()
        {
            var arr = new int[,] {
                {1,1,1,1,0},
                {1,1,1,1,1},
                {1,1,1,0,0}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
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
            var arr = new int[,] {
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1}
                         };
            var matrix = new Matrix(3, 5);
            matrix.MatrixBody = arr;
            var position = new Position(2, 4);
            Assert.IsFalse(Generator.IsPositionValid(matrix, position));
            position = new Position(2, -5);
            Assert.IsFalse(Generator.IsPositionValid(matrix, position));
            position = new Position(-1, 3);
            Assert.IsFalse(Generator.IsPositionValid(matrix, position));
        }
    }
}
