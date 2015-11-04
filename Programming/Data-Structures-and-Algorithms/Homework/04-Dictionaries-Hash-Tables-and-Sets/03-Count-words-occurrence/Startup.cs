namespace _03_Count_words_occurrence
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        private const string FilePath = @"..\..\words.txt";
        private readonly static char[] wordsSeparators = new char[] { ' ', '.', ',', '-', '!', '?' };

        private static void Main()
        {
            Dictionary<string, int> wordsOccurrence;
            using (var fileStream = OpenFile(FilePath))
            {
                wordsOccurrence = CountWordsOccurrence(fileStream);
            }

            var wordsOrderedByOccurrence = wordsOccurrence
                .OrderBy(x => x.Value)
                .ToList();

            PrintWordsOccurrenceCount(wordsOrderedByOccurrence);
        }

        private static void PrintWordsOccurrenceCount(IEnumerable<KeyValuePair<string, int>> wordsOccurrence)
        {
            foreach (var word in wordsOccurrence)
            {
                Console.WriteLine($"{word.Key} : {word.Value}");
            }
        }

        private static Dictionary<string, int> CountWordsOccurrence(StreamReader fileStream)
        {
            var wordsOccurrence = new Dictionary<string, int>();
            string line;
            while ((line = fileStream.ReadLine()) != null)
            {
                var words = line.Split(wordsSeparators, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    if (!wordsOccurrence.Keys.Contains(word))
                    {
                        wordsOccurrence.Add(word, 0);
                    }

                    wordsOccurrence[word]++;
                }
            }

            return wordsOccurrence;
        }

        private static StreamReader OpenFile(string FilePath)
        {
            if (!File.Exists(FilePath))
            {
                throw new IOException("file not found");
            }

            return File.OpenText(FilePath);
        }
    }
}