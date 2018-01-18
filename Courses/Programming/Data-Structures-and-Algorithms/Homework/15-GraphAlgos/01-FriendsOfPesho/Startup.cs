namespace _01_FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static List<int> startNodes;
        static Dictionary<int, int>[] edges = new Dictionary<int, int>[10001];
        static int[] nodeTotalCosts;

        public static void Main()
        {
            //Inputs.SetInput("008");
            GetInput();
            Solve();
        }

        private static void Solve()
        {
            // calc cost from all house to each hospital and choose lowest
            long bestCost = int.MaxValue;
            foreach (var startNode in startNodes)
            {
                Dijkstra(startNode);

                long cost = 0;
                for (int i = 1; i < 10001; i++)
                {
                    if (edges[i] != null && !startNodes.Contains(i))
                    {
                        cost += nodeTotalCosts[i];
                    }
                }

                bestCost = (cost < bestCost) ? cost : bestCost;
            }

            Console.WriteLine(bestCost);
        }

        private static void Dijkstra(int startNode)
        {
            nodeTotalCosts = Enumerable.Repeat(int.MaxValue, 10001).ToArray();
            nodeTotalCosts[startNode] = 0;

            var leftNodes = new HashSet<int>();
            for (int i = 0; i < 10001; i++)
            {
                if (edges[i] != null)
                {
                    leftNodes.Add(i);
                }
            }

            leftNodes.Remove(startNode);

            while (leftNodes.Count > 0)
            {
                var neighbours = edges[startNode];
                foreach (var kvPair in neighbours)
                {
                    var neighbour = kvPair.Key;
                    var neighbourCost = kvPair.Value;
                    if (nodeTotalCosts[startNode] + edges[startNode][neighbour] < nodeTotalCosts[neighbour])
                    {
                        nodeTotalCosts[neighbour] = nodeTotalCosts[startNode] + edges[startNode][neighbour];
                    }
                }

                var min = 0;
                foreach (var node in leftNodes)
                {
                    min = (nodeTotalCosts[min] > nodeTotalCosts[node]) ? node : min;
                }

                if (min == 0)
                {
                    break;
                }

                leftNodes.Remove(startNode);
                startNode = min;
            }
        }

        private static void GetInput()
        {
            var graphParams = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var nodesCount = graphParams[0];
            var edgesCount = graphParams[1];
            var startNodesCount = graphParams[2];

            startNodes = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeParams = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                var node1 = edgeParams[0];
                var node2 = edgeParams[1];
                var edgeCost = edgeParams[2];

                if (Startup.edges[node1] == null)
                {
                    Startup.edges[node1] = new Dictionary<int, int>();
                }

                if (Startup.edges[node2] == null)
                {
                    Startup.edges[node2] = new Dictionary<int, int>();
                }

                var cost = int.MaxValue;
                if (Startup.edges[node1].ContainsKey(node2))
                {
                    cost = Startup.edges[node1][node2];
                }

                if (edgeCost < cost)
                {
                    Startup.edges[node1].Add(node2, edgeCost);
                    Startup.edges[node2].Add(node1, edgeCost);
                }
            }
        }
    }
}
