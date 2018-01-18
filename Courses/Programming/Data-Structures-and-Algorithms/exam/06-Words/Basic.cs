namespace Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static string str1;
        private static string str2;

        private static void Main()
        {
            //Inputs.SetInput("000.001");

            GetInput();
            Solve(str1, str2);
        }

        static Dictionary<string, long> foundCount = new Dictionary<string, long>();

        private static void Solve(string str1, string str2)
        {
            Hash.ComputePowers(str1.Length + 1);
            long totalCount = 0;

            // Find all pairs of substrings
            var pairs = new List<List<string>>();
            for (int i = 0; i < str1.Length; i++)
            {
                var pref = str1.Substring(0, i);
                var suff = str1.Substring(i, str1.Length - i);
                var pair = new List<string>() { pref, suff };
                pairs.Add(pair);
            }

            // For each val in each pair calc occurrences
            for (int i = 0; i < pairs.Count; i++)
            {
                var pair = pairs[i];

                var pref = pair[0];
                var suf = pair[1];

                long prefCount = 0;
                if (!foundCount.ContainsKey(pref))
                {
                    prefCount = Count(pref, str2);
                    foundCount.Add(pref, prefCount);
                }
                else
                {
                    prefCount = foundCount[pref];
                }

                long sufCount = 0;
                if (!foundCount.ContainsKey(suf))
                {
                    sufCount = Count(suf, str2);
                    foundCount.Add(suf, sufCount);
                }
                else
                {
                    sufCount = foundCount[suf];
                }

                totalCount += prefCount * sufCount;
            }

            Console.WriteLine(totalCount);
        }

        private static long Count(string str1, string str2)
        {
            if (str1 == "")
            {
                return 1;
            }

            var len = str1.Length;
            long count = 0;

            var searchHash = new Hash(str1);
            var searchHashVal = searchHash.Value1;

            var currentHash = new Hash(str2.Substring(0, len));
            if (currentHash.Value1 == searchHashVal)
            {
                count++;
            }

            for (int i = len; i < str2.Length; i++)
            {
                var char2add = str2[i];
                currentHash.Add(char2add);

                var char2rem = str2[i - len];
                currentHash.Remove(char2rem, len);

                if (currentHash.Value1 == searchHashVal)
                {
                    count++;
                }
            }

            return count;
        }

        private static void GetInput()
        {
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
        }
    }

    class Hash
    {
        private const ulong BASE1 = 29;
        private const ulong MOD = ulong.MaxValue / BASE1;

        private static ulong[] powers1;

        public static void ComputePowers(int n)
        {
            powers1 = new ulong[n + 1];
            powers1[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers1[i + 1] =
                  powers1[i] * BASE1 % MOD;
            }
        }

        public ulong Value1 { get; private set; }

        public Hash(string str)
        {
            this.Value1 = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public void Add(char c)
        {
            this.Value1 =
                (this.Value1 * BASE1 + c)
                          % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value1 = (MOD +
              this.Value1 - powers1[n] * c % MOD)
                    % MOD;
        }
    }
}