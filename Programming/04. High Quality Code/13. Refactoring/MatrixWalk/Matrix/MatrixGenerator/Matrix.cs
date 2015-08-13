using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkMatrix.MatrixGenerator
{
    internal class Matrix
    {
        private int[,] matrixBody;

        internal int[,] MatrixBody
        {
            get { return matrixBody; }
            set { matrixBody = value; }
        }

        internal Matrix(int rowsLen, int colsLen)
        {
            this.matrixBody = new int[rowsLen, colsLen];
        }

        internal int this[Position position]
        {
            get 
            {
                return this.matrixBody[position.Row, position.Col];
            }
            set
            {
                this.matrixBody[position.Row, position.Col] = value;
            }
        }

        internal int GetLength(int dimension)
        {
            return this.matrixBody.GetLength(dimension);
        }
    }
}
