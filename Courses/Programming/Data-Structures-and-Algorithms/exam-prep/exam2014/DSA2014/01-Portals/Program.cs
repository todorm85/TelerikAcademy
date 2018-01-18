using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA2014
{
    internal class Program
    {
        private static int startRow;
        private static int startCol;
        private static int[,] m;
        private static int rCount;
        private static int cCount;

        private static void Main(string[] args)
        {
            //Inputs.SetInput("003");
            GetInput();
            Solve();
        }

        private static void Solve()
        {
            var v = new bool[rCount, cCount];
            var s = GetSum(v, startRow, startCol, 0);
            Console.WriteLine(s);
        }

        private static int GetSum(bool[,] v, int r, int c, int s)
        {
            if (v[r, c])
            {
                return s;
            }

            v[r, c] = true;
            var t = m[r, c];

            var candidates = new List<int>();
            // check right
            CheckNext(v, r, c + t, ref candidates);

            // check left
            CheckNext(v, r, c - t, ref candidates);

            // check up
            CheckNext(v, r - t, c, ref candidates);

            // check down
            CheckNext(v, r + t, c, ref candidates);

            var maxS = 0;
            for (int i = 0; i < candidates.Count; i += 2)
            {
                var newR = candidates[i];
                var newC = candidates[i + 1];
                var newS = GetSum((bool[,])v.Clone(), newR, newC, m[r, c]);
                if (maxS < newS)
                {
                    maxS = newS;
                }
            }

            return s + maxS;
        }

        private static bool CheckNext(bool[,] v, int r, int c, ref List<int> candidates)
        {
            if (r < rCount && c < cCount && r >= 0 && c >= 0 && m[r,c] >=0)
            {
                candidates.Add(r);
                candidates.Add(c);
                return true;
            }

            return false;
        }

        private static void GetInput()
        {
            var startPos = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            startRow = startPos[0];
            startCol = startPos[1];

            var mDims = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rCount = mDims[0];
            cCount = mDims[1];
            m = new int[rCount, cCount];

            for (int i = 0; i < rCount; i++)
            {
                var row = Console.ReadLine().Split(' ');
                for (int j = 0; j < cCount; j++)
                {
                    if (row[j] != "#")
                    {
                        m[i, j] = int.Parse(row[j]);
                    }
                    else
                    {
                        m[i, j] = -1;
                    }
                }
            }
        }
    }
}