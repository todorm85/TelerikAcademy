using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkMatrix
{
    class ConsoleOutputProvider
    {
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0,5}", matrix[i, j]));
                }

                Console.WriteLine();
            }
        }
    }
}
