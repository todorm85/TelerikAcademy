using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_GoshoPesho
{
    internal class Program
    {
        static int n;
        static int m;

        static int start;
        static int end;

        static int mid1;
        static int mid2;

        static Dictionary<int, int>[] graph;

        private static void Main()
        {
            //Inputs.SetInput(5);

            ReadInput();
            Solve();
        }

        private static void ReadInput()
        {
            int[] graphDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = graphDimensions[0];
            m = graphDimensions[1];

            int[] pathDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            start = pathDimensions[0];
            end = pathDimensions[1];

            int[] mids = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            mid1 = mids[0];
            mid2 = mids[1];

            graph = new Dictionary<int, int>[n + 1];
            for (int i = 1; i <= m; i++)
            {
                int[] edges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edges[0];
                var to = edges[1];
                var cost = edges[2];

                // no need to store all edges between two nodes, only the edge with lowest cost
                if (graph[from] != null && graph[from].ContainsKey(to))
                {
                    var currentCost = graph[from][to];
                    if (currentCost > cost)
                    {
                        graph[from][to] = cost;
                        graph[to][from] = cost;
                    }

                    continue;
                }

                if (graph[from] == null)
                {
                    graph[from] = new Dictionary<int, int>();
                }

                graph[from].Add(to, cost);

                if (graph[to] == null)
                {
                    graph[to] = new Dictionary<int, int>();
                }

                graph[to].Add(from, cost);
            }
        }

        private static void Solve()
        {
            int m1Cost = Djikstra(start, mid1, mid2, end);
            int m2Cost = Djikstra(start, mid2, mid1, end);

            int m1m2Cost = Djikstra(mid1, mid2);

            int m1EndCost = Djikstra(mid1, end, mid2, start);
            int m2EndCost = Djikstra(mid2, end, mid1, start);

            int min = Math.Min(
                m1Cost + m1m2Cost + m2EndCost,
                m2Cost + m1m2Cost + m1EndCost);

            Console.WriteLine(min);
        }

        private static int Djikstra(int start, int end, params int[] excluded)
        {
            var cost = Enumerable.Repeat<int>(int.MaxValue, n + 1).ToArray();
            cost[start] = 0;
            var visited = new bool[n + 1];

            while (true)
            {
                var minCostNode = 0;
                for (int i = 1; i < visited.Length; i++)
                {
                    if (!visited[i] && cost[i] < cost[minCostNode])
                    {
                        minCostNode = i;
                    }
                }

                if (minCostNode == 0)
                {
                    break;
                }

                visited[minCostNode] = true;

                if (graph[minCostNode] == null)
                {
                    continue;
                }

                var neighbours = graph[minCostNode];
                foreach (var neighbour in neighbours)
                {
                    if (excluded.Contains(neighbour.Key))
                    {
                        continue;
                    }

                    if (cost[minCostNode] + neighbour.Value < cost[neighbour.Key])
                    {
                        cost[neighbour.Key] = cost[minCostNode] + neighbour.Value;
                    }
                }
            }

            return cost[end];
        }
    }
}