using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tree;

namespace _01_N_node_tree
{
    internal class Startup
    {
        private static void Main()
        {
            GenerateSampleInput();
            HashSet<TreeNode<int>> treeNodes = ConstructTree();

            Console.WriteLine("Root value");
            TreeNode<int> root = GetRoot(treeNodes);
            Console.WriteLine(root.Value);

            Console.WriteLine("Leaves");
            List<TreeNode<int>> leafNodes = GetLeaves(treeNodes);
            leafNodes.ForEach(x => Console.Write(x.Value + " "));

            Console.WriteLine("\nBranches");
            List<TreeNode<int>> middleNodes = GetMiddlesNodes(treeNodes);
            middleNodes.ForEach(x => Console.Write(x.Value + " "));

            Console.WriteLine("\nLongest Paths");
            List<TreeNode<int>> farthestNodes = GetFarthestNodes(leafNodes);
            farthestNodes.ForEach(x =>
            {
                while (x != null)
                {
                    Console.Write(x.Value + " ");
                    x = x.Parent;
                }
                Console.WriteLine();
            });

            int targetSum = 9;
            Console.WriteLine("Paths with sum {0}.", targetSum);
            List<List<TreeNode<int>>> foundPaths = GetAllPathsWithSum(treeNodes, targetSum);
            foundPaths.ForEach(x => {
                var startNode = x[0];
                var endNode = x[1];
                Console.Write(startNode.Value + " ");
                while (startNode != endNode)
                {
                    startNode = startNode.Parent;
                    Console.Write(startNode.Value + " ");
                }

                Console.WriteLine();
            });
        }

        private static List<List<TreeNode<int>>> GetAllPathsWithSum(HashSet<TreeNode<int>> treeNodes, int targetSum)
        {
            // paths are defined as Lists of two elements
            // start child node and end parent node
            var foundPaths = new List<List<TreeNode<int>>>();
            foreach (var node in treeNodes)
            {
                var currentSum = node.Value;

                var currentNode = node.Parent;
                while (currentNode != null)
                {
                    currentSum += currentNode.Value;
                    if (currentSum == targetSum)
                    {
                        foundPaths.Add(new List<TreeNode<int>>());
                        foundPaths[foundPaths.Count - 1].Add(node);
                        foundPaths[foundPaths.Count - 1].Add(currentNode);
                    }

                    currentNode = currentNode.Parent;
                }
            }

            return foundPaths;
        }

        private static List<TreeNode<int>> GetFarthestNodes(List<TreeNode<int>> leafNodes)
        {
            var farthestNodes = new List<TreeNode<int>>();
            var longestPathLength = 0;
            foreach (var node in leafNodes)
            {
                if (node.Parent == null)
                {
                    continue;
                }

                var currentNode = node.Parent;
                var currentPathLength = 2;

                while (currentNode.Parent != null)
                {
                    currentNode = currentNode.Parent;
                    currentPathLength++;
                }

                if (currentPathLength == longestPathLength)
                {
                    farthestNodes.Add(node);
                    longestPathLength = currentPathLength;
                }

                if (currentPathLength > longestPathLength)
                {
                    farthestNodes.Clear();
                    farthestNodes.Add(node);
                    longestPathLength = currentPathLength;
                }
            }

            return farthestNodes;
        }

        private static List<TreeNode<int>> GetMiddlesNodes(HashSet<TreeNode<int>> treeNodes)
        {
            var middleNodes = new List<TreeNode<int>>();

            foreach (var node in treeNodes)
            {
                if (node.Parent != null && node.Children.Count() > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<TreeNode<int>> GetLeaves(HashSet<TreeNode<int>> treeNodes)
        {
            var leafNodes = new List<TreeNode<int>>();
            foreach (var node in treeNodes)
            {
                if (node.Children.Count == 0)
                {
                    leafNodes.Add(node);
                }
            }

            return leafNodes;
        }

        private static TreeNode<int> GetRoot(HashSet<TreeNode<int>> treeNodes)
        {
            TreeNode<int> root = null;
            foreach (var node in treeNodes)
            {
                if (node.Parent == null)
                {
                    root = node;
                }
            }

            return root;
        }

        private static HashSet<TreeNode<int>> ConstructTree()
        {
            var treeNodes = new HashSet<TreeNode<int>>();
            int nodesCount = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            while (line != string.Empty && line != null)
            {
                var values = line.Split(' ').Select(x => int.Parse(x)).ToList();

                int parentValue = values[0];
                TreeNode<int> parentNode = GetNode(treeNodes, parentValue);

                int childValue = values[1];
                TreeNode<int> childNode = GetNode(treeNodes, childValue);

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;

                treeNodes.Add(parentNode);
                treeNodes.Add(childNode);

                line = Console.ReadLine();
            }

            return treeNodes;
        }

        private static TreeNode<int> GetNode(HashSet<TreeNode<int>> treeNodes, int value)
        {
            var parentNode = treeNodes.FirstOrDefault(x => x.Value == value);
            if (parentNode == null)
            {
                parentNode = new TreeNode<int>(value);
            }

            return parentNode;
        }

        private static void GenerateSampleInput()
        {
            string input = @"7
2 4
3 2
5 0
3 5
5 6
5 1
";
            var reader = new StringReader(input);
            Console.SetIn(reader);
        }
    }
}