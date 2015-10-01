using System;
using System.Collections.Generic;
using System.Collections;
using WalkMatrix.Contracts;

namespace WalkMatrix
{
    public class Matrix
    {
        private int[,] matrixArray;

        public int[,] MatrixArray
        {
            get { return matrixArray; }
            set { matrixArray = value; }
        }

        public Matrix(int rowsLen, int colsLen)
        {
            this.matrixArray = new int[rowsLen, colsLen];
        }

        public int this[IPosition position]
        {
            get
            {
                return this.matrixArray[position.Row, position.Col];
            }
            set
            {
                this.matrixArray[position.Row, position.Col] = value;
            }
        }

        public int GetLength(int dimension)
        {
            return this.matrixArray.GetLength(dimension);
        }

        
    }
}