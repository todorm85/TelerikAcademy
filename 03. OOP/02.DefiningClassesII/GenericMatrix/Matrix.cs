using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    class Matrix<T>
    {
        private T[,] _matrix;

        #region Properties

        public int RowsCount
        {
            get
            {
                return this._matrix.GetLength(0);
            }
        }

        public int ColsCount
        {
            get
            {
                return this._matrix.GetLength(1);
            }
        }

        public T this[int row, int col]
        {
            get
            {
                this.CheckIndexes(row, col);
                return this._matrix[row, col];
            }
            set
            {
                this.CheckIndexes(row, col);
                this._matrix[row, col] = value;
            }
        }

        #endregion

        public Matrix(int rowsCount, int colsCount)
        {
            if (rowsCount <= 0 || colsCount <= 0)
            {
                throw new ArgumentException("Rows or columns count cannot be <= 0");
            }

            this._matrix = new T[rowsCount, colsCount];
        }

        #region PublicMethods

        public void GenerateRandom()
        {
            Random r = new Random();

            for (int i = 0; i < this.RowsCount; i++)
            {
                for (int j = 0; j < this.ColsCount; j++)
                {
                    decimal randomDecimal = Convert.ToDecimal(r.Next(1, 100) + r.NextDouble());
                    this[i, j] = ReturnGenericFromDecimal<T>(typeof(T), randomDecimal);
                }
            }
        }

        // this method allows for addition of two different type matrixes
        public void Add<T2>(Matrix<T2> m1)
        {
            if (m1.RowsCount != this.RowsCount || m1.ColsCount != this.ColsCount)
            {
                throw new ArgumentException("Matrixes are not of equal dimensions.");
            }

            for (int row = 0; row < m1.RowsCount; row++)
            {
                for (int col = 0; col < m1.ColsCount; col++)
                {
                    decimal firstValue = Convert.ToDecimal(m1[row, col]);
                    decimal secondValue = Convert.ToDecimal(this[row, col]);
                    decimal sumValue = firstValue + secondValue;
                    this[row, col] = ReturnGenericFromDecimal<T>(typeof(T), sumValue);
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.RowsCount != m2.RowsCount || m1.ColsCount != m2.ColsCount)
            {
                throw new ArgumentException("Matrixes are not of equal dimensions.");
            }

            Matrix<T> m3 = new Matrix<T>(m1.RowsCount,m1.ColsCount);

            for (int row = 0; row < m1.RowsCount; row++)
            {
                for (int col = 0; col < m1.ColsCount; col++)
                {
                    decimal firstValue = Convert.ToDecimal(m1[row, col]);
                    decimal secondValue = Convert.ToDecimal(m2[row, col]);
                    decimal sumValue = firstValue + secondValue;
                    m3[row, col] = ReturnGenericFromDecimal<T>(typeof(T), sumValue);
                }
            }

            return m3;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.RowsCount != m2.RowsCount || m1.ColsCount != m2.ColsCount)
            {
                throw new ArgumentException("Matrixes are not of equal dimensions.");
            }

            Matrix<T> m3 = new Matrix<T>(m1.RowsCount, m1.ColsCount);

            for (int row = 0; row < m1.RowsCount; row++)
            {
                for (int col = 0; col < m1.ColsCount; col++)
                {
                    decimal firstValue = Convert.ToDecimal(m1[row, col]);
                    decimal secondValue = Convert.ToDecimal(m2[row, col]);
                    decimal sumValue = firstValue - secondValue;
                    m3[row, col] = ReturnGenericFromDecimal<T>(typeof(T), sumValue);
                }
            }

            return m3;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.ColsCount != m2.RowsCount)
            {
                throw new ArgumentException("First matrix number of columns must equal second matrix number of rows for a valid matrix multiplication");
            }

            Matrix<T> m3 = new Matrix<T>(m1.RowsCount, m2.ColsCount);

            for (int m3row = 0; m3row < m3.RowsCount; m3row++)
            {
                for (int m3col = 0; m3col < m3.ColsCount; m3col++)
                {
                    decimal productsSum = 0;

                    for (int i = 0; i < m2.RowsCount; i++)  // or m1.ColsCount
                    {
                        decimal firstValue = Convert.ToDecimal(m1[m3row, i]);
                        decimal secondValue = Convert.ToDecimal(m2[i, m3col]);
                        productsSum += firstValue*secondValue;
                    }

                    m3[m3row, m3col] = ReturnGenericFromDecimal<T>(typeof(T), productsSum);
                }
            }

            return m3;
        }

        public static bool operator true(Matrix<T> m)
        {
            for (int row = 0; row < m.RowsCount; row++)
            {
                for (int col = 0; col < m.ColsCount; col++)
                {
                    if (Convert.ToInt32(m[row,col]) != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator false(Matrix<T> m)
        {
            for (int row = 0; row < m.RowsCount; row++)
            {
                for (int col = 0; col < m.ColsCount; col++)
                {
                    if (Convert.ToInt32(m[row, col]) != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
            
        }

        #endregion

        #region PrivateMethods

        private void CheckIndexes(int row, int col)
        {
            if (row < 0 || row >= this._matrix.GetLength(0) ||
                    col < 0 || col >= this._matrix.GetLength(1))
            {
                throw new ArgumentException("Trying to access matrix with index of row or column that is out of range.");
            }
        }

        private static T2 ReturnGenericFromDecimal<T2>(Type targetType, decimal dec)
        {
            T2 result;
            switch (targetType.ToString())
            {
                case "System.UByte":
                    result = (T2)(Object)Convert.ToByte(dec);
                    break;
                case "System.Byte":
                    result = (T2)(Object)Convert.ToSByte(dec);
                    break;
                case "System.Int16":
                    result = (T2)(Object)Convert.ToInt16(dec);
                    break;
                case "System.Int32":
                    result = (T2)(Object)Convert.ToInt32(dec);
                    break;
                case "System.Int64":
                    result = (T2)(Object)Convert.ToInt64(dec);
                    break;
                case "System.UInt16":
                    result = (T2)(Object)Convert.ToUInt16(dec);
                    break;
                case "System.UInt32":
                    result = (T2)(Object)Convert.ToUInt32(dec);
                    break;
                case "System.UInt64":
                    result = (T2)(Object)Convert.ToUInt64(dec);
                    break;

                case "System.Double":
                    result = (T2)(Object)(Convert.ToDouble(dec));
                    break;
                case "System.Single":
                    result = (T2)(Object)(Convert.ToSingle(dec));
                    break;
                case "System.Decimal":
                    result = (T2)(Object)(Convert.ToDecimal(dec));
                    break;

                default:
                    throw new Exception("Invalid type");
            }

            return result;
        }

        #endregion
    }
}
