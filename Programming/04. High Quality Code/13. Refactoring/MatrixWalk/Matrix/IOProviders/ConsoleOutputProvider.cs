using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkMatrix.MatrixGenerator;

namespace WalkMatrix.IOProviders
{
    internal class ConsoleOutputProvider
    {
        internal static void PrintMatrix(Matrix matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var pos = new Position(row, col);
                    Console.Write(string.Format("{0,5}", matrix[pos]));
                }

                Console.WriteLine();
            }
        }
    }
}
