// Write a program based on dynamic programming to solve the "Knapsack Problem": you are
// given N products, each has weight Wi and costs Ci and a knapsack of capacity M and you
// want to put inside a subset of the products with highest cost and weight ≤ M.The
// numbers N, M, Wi and Ci are integers in the range[1..500].

// USED REFERENCE FOR SOLUTION: https://en.wikipedia.org/wiki/Knapsack_problem

namespace _01_KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            int maxW = 10; // max weight
            int n = 6; // products count
            var v = new int[] { 2, 12, 5, 4, 3, 13 }; // products values
            var w = new int[] { 3, 8, 4, 1, 2, 8 }; // products weights

            // each cell m[i, j] in matrix m holds the max possible sum of values from all
            // elements in subset {1 to i} with sum of weight less than 'j'. Or in short -
            // the answer to the problem for elements 1 to i and capacity j.
            var m = new int[n + 1, maxW + 1];

            // i : element
            // j : capacity
            // w[i-1] : weight of element 'i'
            // v[i-1] : value of element 'i'
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= maxW; j++)
                {
                    
                    if (w[i - 1] <= j)
                    {
                        // if the current element 'i' weight is less than or equal to the
                        // current capacity then we have to possibilities for max value
                        // sum and we must choose the bigger one to store in m. One
                        // possibility is to get the previously found max sum for current
                        // capacity j and elements 1 to i-1, which is m[i-1, j]. The other option
                        // is the current element i value (v[i-1]) and the previously
                        // found result for 1 to i-1 values and max weight: j - w[i-1]
                        // (current max weight minus current element weight). Note: for
                        // element i the weight is w[i-1] because we have zero based
                        // indexes for array w, but in matrix m we start indexing the
                        // elements from 1.
                        m[i, j] = Math.Max(m[i - 1, j], v[i - 1] + m[i - 1, j - w[i - 1]]);
                    }
                    else
                    {
                        m[i, j] = m[i - 1, j];
                    }
                }
            }

            // m[n, maxW] is values sum of the subset of elements from all n elements,
            // that is the max sum for which the sum of the elements weight is less than
            // max weight
            Console.WriteLine($"Optimal cost: {m[n, maxW]}");
        }
    }
}
