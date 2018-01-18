using System;
using System.Collections.Generic;
using System.Linq;

namespace Renewal
{
    internal class Program
    {
        private static int[,] m;

        private static int[,] b;

        private static int[,] d;
        private static int n;

        private static void Main()
        {
            //Inputs.SetInput("003");

            GetInput();
            Solve();
        }

        private static void Solve()
        {
            long cost = 0;

            var ex = GetEdges(m, d, 1);

            var rem = Kruskal(ex.ToList(), true, new List<Edge>());   // max span tree
            cost += CalculateCostAfterDestruction(rem, ex);

            var nonEx = GetEdges(m, b, 0);
            var potential = nonEx.ToList();

            var final = Kruskal(potential.ToList(), false, rem); // min span tree
            cost += CalculateCostAfterConstruction(final, rem);

            Console.WriteLine(cost);
        }

        private static long CalculateCostAfterConstruction(List<Edge> after, List<Edge> before)
        {
            long c = 0;
            foreach (var a in after)
            {
                if (!before.Contains(a))
                {
                    c += a.Weight;
                }
            }

            return c;
        }

        private static long CalculateCostAfterDestruction(List<Edge> after, List<Edge> before)
        {
            long c = 0;
            foreach (var b in before)
            {
                if (!after.Contains(b))
                {
                    c += b.Weight;
                }
            }

            return c;
        }

        private static List<Edge> Kruskal(List<Edge> edges, bool max, List<Edge> skip)
        {
            if (max)
            {
                edges = edges.OrderByDescending(x => x.Weight).ToList();
                if (skip.Count > 0)
                {
                    skip = skip.OrderByDescending(x => x.Weight).ToList();
                }
            }
            else
            {
                edges = edges.OrderBy(x => x.Weight).ToList();
                if (skip.Count > 0)
                {
                    skip = skip.OrderBy(x => x.Weight).ToList();
                }
            }

            if (skip.Count > 0)
            {
                edges = skip.Concat(edges).ToList();
            }


            int[] tree = new int[n + 1]; //we start from 1, not from 0
            var mpd = new List<Edge>();
            int treesCount = 1;

            treesCount = FindSpanningTree(edges, tree, mpd, treesCount);

            return mpd.ToList();
        }

        private static int FindSpanningTree(List<Edge> edges, int[] tree, List<Edge> mpd, int treesCount)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    mpd.Add(edge);
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        mpd.Add(edge);
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }
                        mpd.Add(edge);
                    }
                }
            }
            return treesCount;
        }

        private static List<Edge> GetEdges(int[,] neighbours, int[,] cost, int flag)
        {
            var ex = new List<Edge>();
            for (int i = 0; i < neighbours.GetLength(0); i++)
            {
                for (int j = i; j < neighbours.GetLength(1); j++)
                {
                    if (i != j && neighbours[i, j] == flag)
                    {
                        ex.Add(new Edge(i, j, cost[i, j]));
                    }
                }
            }

            return ex;
        }

        private static void GetInput()
        {
            n = int.Parse(Console.ReadLine());

            m = ParseMatrix(n);

            //PrintMatrix(m);

            b = ParseMatrix(n);

            //PrintMatrix(b);

            d = ParseMatrix(n);

            //PrintMatrix(d);
        }

        private static int[,] ParseMatrix(int n)
        {
            var m = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().ToCharArray().Select(ParseCostLetter).ToArray();
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = line[j];
                }
            }

            return m;
        }

        private static int ParseCostLetter(char l)
        {
            // check nums
            if (l < 58)
            {
                return l - 48;
            }

            // check Caps
            if (l < 91)
            {
                return l - 65;
            }

            // Lowers
            return l - 97 + 26;
        }

        private static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write(m[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);
            //if (weightCompared == 0)
            //{
            //    return this.StartNode.CompareTo(other.StartNode);
            //}

            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
        }
    }
}