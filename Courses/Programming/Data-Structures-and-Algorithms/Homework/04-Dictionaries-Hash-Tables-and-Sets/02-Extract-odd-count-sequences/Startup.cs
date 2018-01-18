namespace _02_Extract_odd_count_sequences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Startup
    {
        private static void Main()
        {
            var words = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL"};

            var wordsCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordsCount.Keys.Contains(word))
                {
                    wordsCount.Add(word, 0);
                }

                wordsCount[word]++;
            }

            foreach (var word in wordsCount.Keys)
            {
                if (wordsCount[word] % 2 == 1)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
