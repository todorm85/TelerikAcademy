using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    class TestMatrix
    {
        static void Main()
        {
            Console.WriteLine("\n//// INITIALIZE DOUBLE AND PRINT EMPTY DOUBLE MATRIX");
            Matrix<double> doubleMatrix = new Matrix<double>(3, 4);
            PrintMatrix(doubleMatrix);
            Console.WriteLine("//// INITIALIZE WITH RANDOM DOUBLE VALUES AND PRINT DOUBLE MATRIX");
            doubleMatrix.GenerateRandom();
            PrintMatrix(doubleMatrix);

            Console.WriteLine("\n//// INITIALIZE INT AND PRINT EMPTY INT MATRIX");
            Matrix<int> intMatrix = new Matrix<int>(3, 4);
            PrintMatrix(intMatrix);
            Console.WriteLine("//// INITIALIZE WITH RANDOM INT VALUES AND PRINT INT MATRIX");
            intMatrix.GenerateRandom();
            PrintMatrix(intMatrix);

            Console.WriteLine("\n//// INITIALIZE FLOAT AND PRINT EMPTY FLOAT MATRIX");
            Matrix<float> floatMatrix = new Matrix<float>(3, 4);
            PrintMatrix(floatMatrix);
            Console.WriteLine("//// INITIALIZE WITH RANDOM FLOAT VALUES AND PRINT FLOAT MATRIX");
            floatMatrix.GenerateRandom();
            PrintMatrix(floatMatrix);

            Console.WriteLine("\n//// INITIALIZE DECIMAL AND PRINT EMPTY DECIMAL MATRIX");
            Matrix<decimal> decimalMatrix = new Matrix<decimal>(3, 4);
            PrintMatrix(decimalMatrix);
            Console.WriteLine("//// INITIALIZE WITH RANDOM DECIMAL VALUES AND PRINT DECIMAL MATRIX");
            decimalMatrix.GenerateRandom();
            PrintMatrix(decimalMatrix);

            Console.WriteLine("\n//// TRYING TO INITIALIZE MATRIX WITH NEGATIVE ROWS COUNT");
            try
            {
                Matrix<decimal> invalidMatrix = new Matrix<decimal>(-3, 4);
            }
            catch (Exception exx)
            {
                Console.WriteLine("Exception message: {0}", exx.Message);
            }

            Console.WriteLine("\n//// TRYING TO ACCESS MATRIX WITH NEGATIVE ROWS INDEX");
            try
            {
                intMatrix[-1, 1] = 0;
            }
            catch (Exception exx)
            {
                Console.WriteLine("Exception message: {0}", exx.Message);
            }

            Console.WriteLine("\n//// TRYING TO ACCESS MATRIX WITH BIGGER THAN MAX ROWS INDEX");
            try
            {
                intMatrix[100, 1] = 0;
            }
            catch (Exception exx)
            {
                Console.WriteLine("Exception message: {0}", exx.Message);
            }

            Console.WriteLine("\n//// TESTING ADDITION OF INT MATRIXES WITH METHOD");
            Matrix<int> firstMatrix = new Matrix<int>(3, 4);
            Console.WriteLine("//// FIRST MATRIX OF INTEGERS");
            firstMatrix.GenerateRandom();
            PrintMatrix(firstMatrix);
            Console.WriteLine("//// SECOND MATRIX OF DOUBLES");
            Matrix<double> secondMatrix = new Matrix<double>(3, 4);
            secondMatrix.GenerateRandom();
            PrintMatrix(secondMatrix);
            Console.WriteLine("//// FIRST MATRIX AFTER THE ADDITION OF THE SECOND MATRIX");
            firstMatrix.Add(secondMatrix);
            PrintMatrix(firstMatrix);

            Console.WriteLine("\n//// TRYING TO SUM MATRIXES OF DIFFERENT SIZE");
            try
            {
                secondMatrix = new Matrix<double>(3, 5);
                secondMatrix.GenerateRandom();
                firstMatrix.Add(secondMatrix);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception message: {0}", ex.Message);
            }

            Console.WriteLine("\n//// TESTING OVERLOADED OPERATORS");
            Console.WriteLine("//// FIRST MATRIX OF INTEGERS");
            Matrix<int> firstIntMatrix = new Matrix<int>(3, 4);
            firstIntMatrix.GenerateRandom();
            PrintMatrix(firstIntMatrix);
            Console.WriteLine("//// SECOND MATRIX OF INTEGERS");
            Matrix<int> secondIntMatrix = new Matrix<int>(3, 4);
            secondIntMatrix.GenerateRandom();
            PrintMatrix(secondIntMatrix);
            Console.WriteLine("//// SUMMED MATRIX OF INTEGERS WITH OVERLOADED OPERATOR");
            Matrix<int> resultIntMatrix = firstIntMatrix + secondIntMatrix;
            PrintMatrix(resultIntMatrix);
            Console.WriteLine("//// SUBTRACTION OF MATRIXES OF INTEGERS WITH OVERLOADED OPERATOR");
            resultIntMatrix = firstIntMatrix - secondIntMatrix;
            PrintMatrix(resultIntMatrix);
            Console.WriteLine("\n//// MULTIPLICATION OF MATRIXES OF INTEGERS WITH OVERLOADED OPERATOR");
            Console.WriteLine("//// FIRST MATRIX OF INTEGERS");
            firstIntMatrix = new Matrix<int>(2, 4);
            firstIntMatrix.GenerateRandom();
            PrintMatrix(firstIntMatrix);
            Console.WriteLine("//// SECOND MATRIX OF INTEGERS");
            secondIntMatrix = new Matrix<int>(4, 2);
            secondIntMatrix.GenerateRandom();
            PrintMatrix(secondIntMatrix);
            Console.WriteLine("//// MULTIPLIED RESULTANT MATRIX OF INTEGERS WITH OVERLOADED OPERATOR");
            resultIntMatrix = firstIntMatrix * secondIntMatrix;
            PrintMatrix(resultIntMatrix);

            Console.WriteLine("\n//// MULTIPLICATION OF MATRIXES THAT CANNOT BE MULTIPLIED");
            firstIntMatrix = new Matrix<int>(2, 4);
            secondIntMatrix = new Matrix<int>(5, 2);
            try
            {
                resultIntMatrix = firstIntMatrix * secondIntMatrix;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception message: {0}", ex.Message);
            }

            if (firstIntMatrix)
            {
                Console.WriteLine(true);
            }
        }

        static void PrintMatrix<T>(Matrix<T> input)
        {
            for (int i = 0; i < input.RowsCount; i++)
            {
                for (int j = 0; j < input.ColsCount; j++)
                {
                    Console.Write("{0,6:0.#}", input[i, j]);
                }

                Console.WriteLine();
            }
        }


    }
}
