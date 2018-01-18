using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem
{
    internal class Program
    {
        public static List<Node> graph = new List<Node>();


        private static void Main()
        {
            //Inputs.SetInput("000.004");
            //Inputs.SetInput(0);

            GetInput();
            Solve();
        }

        private static void Solve()
        {
            long maxTime = 0;
            while (graph.Count > 0)
            {
                var subGraph = FindSubgraph();

                long time = CalcTime(subGraph);

                if (time == -1)
                {
                    Console.WriteLine(-1);
                    return;
                }

                if (time >= maxTime)
                {
                    maxTime = time;
                }
            }

            Console.WriteLine(maxTime);
        }

        private static long CalcTime(List<Node> subGraph)
        {
            long maxTime = 0;

            while (subGraph.Count > 0)
            {
                var noParents = subGraph.Where(x => x.Parents.Count == 0).ToList();
                if (noParents.Count == 0)
                {
                    return -1;
                }

                // set new values
                foreach (var parent in noParents)
                {
                    subGraph.Remove(parent);
                    if (parent.Value > maxTime)
                    {
                        maxTime = parent.Value;
                    }

                    foreach (var child in parent.Children)
                    {
                        if (!subGraph.Contains(child))
                        {
                            return -1;
                        }

                        if (child.Value + parent.Value + parent.NewValue > child.NewValue + child.Value)
                        {
                            child.NewValue = parent.Value + parent.NewValue;
                            if (child.NewValue + child.Value > maxTime)
                            {
                                maxTime = child.Value + child.NewValue;
                            }
                        }

                        child.Parents.Remove(parent);
                    }

                }
            }

            return maxTime;
        }

        private static List<Node> FindSubgraph()
        {
            var sub = new List<Node>();
            var v = new HashSet<Node>();

            var n = graph[0];
            graph.Remove(n);

            var q = new Queue<Node>();
            q.Enqueue(n);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                v.Add(node);
                sub.Add(node);

                foreach (var child in node.Children)
                {
                    if (!v.Contains(child))
                    {
                        q.Enqueue(child);
                        graph.Remove(child);
                    }
                }

                foreach (var parent in node.Parents)
                {
                    if (!v.Contains(parent))
                    {
                        q.Enqueue(parent);
                        graph.Remove(parent);
                    }
                }
            }

            return sub;
        }

        private static void GetInput()
        {
            var n = int.Parse(Console.ReadLine());
            var times = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 1; i <= n; i++)
            {
                var node = new Node(times[i - 1], i);
                graph.Add(node);
            }

            for (int i = 1; i <= n; i++)
            {
                var req = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (req[0] == 0)
                {
                    continue;
                }

                for (int j = 0; j < req.Length; j++)
                {
                    var child = graph.FirstOrDefault(x => x.Id == i);
                    var parent = graph.FirstOrDefault(x => x.Id == req[j]);

                    child.Parents.Add(parent);
                    parent.Children.Add(child);
                }
            }
        }
    }

    public class Node
    {
        public Node(long value, int id)
        {
            this.Id = id;
            this.Value = value;
            this.Children = new List<Node>();
            this.Parents = new List<Node>();
        }

        public long Value { get; set; }

        public long NewValue { get; set; }

        public ICollection<Node> Children { get; set; }

        public ICollection<Node> Parents { get; set; }

        public int Id { get; set; }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}