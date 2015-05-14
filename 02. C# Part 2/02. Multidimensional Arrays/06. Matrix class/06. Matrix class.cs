using System;
//### Problem* 06. Matrix class
//*	Write a class `Matrix`, to hold a matrix of integers. Overload the operators for adding, subtracting and multiplying of matrices, indexer for accessing the matrix content and `ToString()`.
class MatrixUI
{
    static void Main()
    {
        Matrix matrixFirst = new Matrix(2,2);
        Matrix matrixSecond = new Matrix(2, 2);

        matrixFirst[0, 0] = 1;  // your input here !!!!!!!!
        matrixFirst[0,1] = 2;
        matrixSecond[1, 0] = 3;
        matrixSecond[0,1] = 4;

        Matrix resultMatrix = matrixFirst + matrixSecond;
        Console.WriteLine("\nFirst");
        PrintMatrix(matrixFirst);
        Console.WriteLine("\nSecond");
        PrintMatrix(matrixSecond);
        Console.WriteLine("\nSum");
        PrintMatrix(resultMatrix);

        resultMatrix = matrixFirst - matrixSecond;
        Console.WriteLine("\nSubtraction");
        PrintMatrix(resultMatrix);

        resultMatrix = matrixFirst * matrixSecond;
        Console.WriteLine("\nMultiplication");
        PrintMatrix(resultMatrix);

        // print the matrix result using ToString()
        Console.WriteLine();
        Console.WriteLine(resultMatrix.ToString());
    }

    static void PrintMatrix(Matrix instance)
    {
        for (int row = 0; row < instance.Rows; row++)
        {
            for (int col = 0; col < instance.Columns; col++)
            {
                Console.Write(instance[row,col] + " ");
            }

            Console.WriteLine();
        }
    }
}

