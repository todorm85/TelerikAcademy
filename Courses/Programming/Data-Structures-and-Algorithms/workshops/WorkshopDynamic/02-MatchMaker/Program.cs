namespace _02_MatchMaker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        private static readonly Dictionary<string, List<string>> interestNodes = new Dictionary<string, List<string>>();
        private static readonly HashSet<string> boys = new HashSet<string>();
        private static readonly HashSet<string> girls = new HashSet<string>();


        private static readonly Queue<string> q = new Queue<string>();
        private static readonly Dictionary<string, int> foundMatches = new Dictionary<string, int>();

        public static void Main()
        {
            ReadInput();
            Solve();
        }

        private static void ReadInput()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string gender = Console.ReadLine();
                Console.ReadLine();
                var interests = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct();

                foreach (var interest in interests)
                {
                    string startNode;
                    string endNode;
                    if (gender == "m")
                    {
                        startNode = name;
                        endNode = interest;

                        if (!interestNodes.ContainsKey(endNode))
                        {
                            interestNodes.Add(endNode, new List<string>());
                        }

                        boys.Add(name);
                    }
                    else
                    {
                        startNode = interest;
                        endNode = name;

                        girls.Add(name);
                    }

                    if (!interestNodes.ContainsKey(startNode))
                    {
                        interestNodes.Add(startNode, new List<string>());
                    }

                    interestNodes[startNode].Add(endNode);
                }
            }
        }

        private static void Solve()
        {
            int bestMatch = 0;
            string bestBoy = string.Empty;
            string bestGirl = string.Empty;

            foreach (string boy in boys)
            {
                foundMatches.Clear();
                q.Enqueue(boy);
                while (q.Count > 0)
                {
                    string current = q.Dequeue();
                    foreach (string next in interestNodes[current])
                    {
                        if (girls.Contains(next))
                        {
                            if (!foundMatches.ContainsKey(next))
                            {
                                foundMatches.Add(next, 0);
                            }

                            ++foundMatches[next];
                        }
                        else
                        {
                            q.Enqueue(next);
                        }
                    }
                }

                int currentMatch = 0;
                string currentGal = string.Empty;
                foreach (var match in foundMatches)
                {
                    if (currentMatch < match.Value)
                    {
                        currentMatch = match.Value;
                        currentGal = match.Key;
                    }
                }

                if (bestMatch < currentMatch || (bestMatch == currentMatch && 0 < string.Compare(bestBoy, boy)))
                {
                    bestMatch = currentMatch;
                    bestBoy = boy;
                    bestGirl = currentGal;
                }
            }

            Console.WriteLine("{0} and {1} have {2} common interest{3}!", bestBoy, bestGirl, bestMatch, bestMatch == 1 ? "" : "s");
        }
    }
}