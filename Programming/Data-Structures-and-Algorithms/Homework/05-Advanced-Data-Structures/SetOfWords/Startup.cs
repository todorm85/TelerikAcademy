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
        //              and trie is O(1). Of course hashmaps may have collisions. But the
        //              overall algorithm complexity is still very close to constant. The
        //              overhead being added by the hashfunction is also a constant and
        //              usually hashfunctions are highly efficient calculations so they
        //              don`t present any significant overhead.

        private static readonly char[] wordDelimiters = new char[] { ' ', ',', ':', '-', '!', '.', ',', '?'};
        private const string FilePath = @"..\..\huge_lorem.txt";

        private static Dictionary<string, int> words = new Dictionary<string, int>();

        static void Main()
        {
            CountWordsInFile();

            PrintWordsCount();
        }

        private static void PrintWordsCount()
        {
            foreach (var kvPair in words)
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
                var i = 0;
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
                    i++;
                }
            }
        }

        private static void CountWord(string word)
        {
            if (words.ContainsKey(word))
            {
                words[word]++;
            }
            else
            {
                words.Add(word, 1);
            }
        }
    }
}
