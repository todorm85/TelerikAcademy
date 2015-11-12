using System;
using System.IO;
using System.Linq;

namespace _02_ColorRabbits
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //GenerateInput();
            int[] answers = ParseAnswers();
            var groupedAnswers = answers.GroupBy(x => x);

            int minCount = 0;
            foreach (var group in groupedAnswers)
            {
                var rabbitAnswer = group.Key;
                var askedRabbitCount = group.Count();
                if (rabbitAnswer > askedRabbitCount)
                {
                    minCount += rabbitAnswer + 1;
                }
                else
                {
                    minCount += (askedRabbitCount / (rabbitAnswer + 1)) * (rabbitAnswer + 1);
                    if (askedRabbitCount % (rabbitAnswer + 1) != 0)
                    {
                        minCount += rabbitAnswer + 1;
                    }
                }
            }

            Console.WriteLine(minCount);
        }

        private static int[] ParseAnswers()
        {
            var askedRabbitsCount = int.Parse(Console.ReadLine());
            var answers = new int[askedRabbitsCount];
            for (int i = 0; i < askedRabbitsCount; i++)
            {
                answers[i] = int.Parse(Console.ReadLine());
            }

            return answers;
        }

        private static void GenerateInput()
        {
            string input = @"9
2
2
44
2
2
2
444
2
2";
            var reader = new StringReader(input);
            Console.SetIn(reader);
        }
    }
}