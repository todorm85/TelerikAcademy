namespace SetOfWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    class Startup
    {
        // EXPLANATION: I decided not to use trie since it has no obvious advantages over
        //              hashmap (Dictionary in c#) in the current task. Tries are useful
        //              for autocomplete or search suggestions, but in this case we only
        //              need to find the currently processed word in the data structure
        //              and increase the value associated with it, which in both hashmap
        //              and trie is O(1). We are sure to read the whole word since we are
        //              processing a very large file with a stream, that goes through
        //              every character. So wehn we encounter a full word we simply check
        //              its existance in the hash O(1). If we were to use trie, we would
        //              have to do this check for every character. Of course hashmaps may
        //              have collisions. But the overall algorithm complexity is still
        //              very close to constant. The overhead being added by the
        //              hashfunction is also a constant and usually hashfunctions are
        //              highly efficient calculations so they don`t present any
        //              significant overhead.

        private static readonly char[] wordDelimiters = new char[] { ' ', ',', ':', '-', '!', '.', ',', '?' };
        private const string FilePath = @"..\..\huge_lorem.txt";

        private static Dictionary<string, int> wordsSetToCount = new Dictionary<string, int>()
        {
            { "Minus", 1 },
            { "Harum", 1 },
            { "Odit", 1 },
            { "Facere", 1 },
            { "Tempore", 1 },
        }
    ;

        static void Main()
        {
            CountWordsInFile();

            PrintWordsCount();
        }

        private static void PrintWordsCount()
        {
            foreach (var kvPair in wordsSetToCount)
            {
                Console.WriteLine($"{kvPair.Key} : {kvPair.Value}");
            }
        }

        private static void CountWordsInFile()
        {
            Console.WriteLine("Counting words...");
            var fileReader = new StreamReader(FilePath);
            using (fileReader)
            {
                var sb = new StringBuilder();
                while (!fileReader.EndOfStream)
                {
                    var symbol = (char)fileReader.Read();
                    if (wordDelimiters.Contains(symbol) && sb.Length != 0)
                    {
                        var word = (sb.ToString().Trim());
                        CountWord(word);
                        sb.Clear();
                        continue;
                    }

                    sb.Append(symbol);
                }
            }
        }

        private static void CountWord(string word)
        {
            if (wordsSetToCount.ContainsKey(word))
            {
                wordsSetToCount[word]++;
            }
            //else
            //{
            //    wordsSetToCount.Add(word, 1);
            //}
        }
    }
}
