//An undirected graph has an Eulerian cycle if and only if every vertex has even degree
//An undirected graph has an Eulerian trail if and only if at most two vertices have odd degree,

namespace Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    internal class Program
    {
        private static void Main()
        {
            //Inputs.SetInput("000.001");
            //Inputs.SetInput(0);

            GetInput();
            Solve();
        }

        private static void Solve()
        {
            var cleaners = new Dictionary<string, string>();
            foreach (var kvPair in hoods)
            {
                var hoodName = kvPair.Key;
                var nodesCount = kvPair.Value;

                int oddDegreeVertexCount = 0;
                foreach (var n in nodesCount)
                {
                    if (oddDegreeVertexCount > 2)
                    {
                        break;
                    }

                    if (n%2!=0)
                    {
                        oddDegreeVertexCount++;
                    }
                }

                if (oddDegreeVertexCount > 2)
                {
                    cleaners.Add(hoodName, "Dirty");
                }

                if (oddDegreeVertexCount > 0 && oddDegreeVertexCount <= 2)
                {
                    cleaners.Add(hoodName, "Titan");
                }

                if (oddDegreeVertexCount == 0)
                {
                    cleaners.Add(hoodName, "Wolf");
                }
            }

            foreach (var kvPair in cleaners)
            {
                Console.WriteLine("{0} {1}", kvPair.Key, kvPair.Value);
            }
        }

        static Dictionary<string, int[]> hoods;
        private static void GetInput()
        {
            hoods = new Dictionary<string, int[]>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var nParams = Console.ReadLine().Split(' ');
                var name = nParams[0];
                var nodesCount = int.Parse(nParams[1]);
                var edgesCount = int.Parse(nParams[2]);

                var nodeDegrees = new int[nodesCount];
                for (int j = 0; j < edgesCount; j++)
                {
                    var edgeParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    var n1 = edgeParams[0] - 1;
                    var n2 = edgeParams[1] - 1;
                    nodeDegrees[n1]++;
                    nodeDegrees[n2]++;
                }

                hoods.Add(name, nodeDegrees);
            }
        }
    }
}