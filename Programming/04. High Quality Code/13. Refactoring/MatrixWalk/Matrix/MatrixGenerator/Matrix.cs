using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkMatrix.MatrixGenerator
{
    internal class Matrix
    {
        private int[,] matrix;

        internal Matrix(int rowsLen, int colsLen)
        {
            this.matrix = new int[rowsLen, colsLen];
        }

        internal int this[int row, int col]
        {
            get 
            {
                return this.matrix[row, col];
            }
            set
            {
                this.matrix[row, col] = value;
            }
        }
    }
}
