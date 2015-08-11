using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WalkMatrix
{
    public class EntryPoint
    {
        public static void Main()
        {
            int matrixLength = ConsoleInputProvider.GetInput();
            int[,] matrix = MatrixGenerator.Generate(matrixLength);
            ConsoleOutputProvider.PrintMatrix(matrix);
        }
    }
}
