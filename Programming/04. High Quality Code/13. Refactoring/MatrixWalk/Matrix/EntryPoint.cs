using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkMatrix.IOProviders;
using WalkMatrix.MatrixGenerator;

namespace WalkMatrix
{
    public class EntryPoint
    {
        public static void Main()
        {
            int matrixLength = ConsoleInputProvider.GetInput();
            Matrix matrix = Generator.Generate(matrixLength);
            ConsoleOutputProvider.PrintMatrix(matrix);
        }
    }
}
