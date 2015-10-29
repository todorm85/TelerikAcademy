using System;
using System.Collections.Generic;

namespace Common
{
    public static class DataProvider
    {
        private static InputProvider input = new InputProvider(Console.In);
        private static OutputProvider output = new OutputProvider(Console.Out);
        private static IRandomGenerator random = new RandomGenerator();

        public static List<T> GetNumbersListInput<T>(string breakLine = "")
            where T : IConvertible
        {
            output.WriteLine(String.Format("Please enter sequence numbers of type {1}, each on new line. Enter '{0}' to finish.", breakLine, default(T).GetType()));
            var numbers = input.ReadAllLines<T>(breakLine: breakLine);
            return numbers;
        }

        public static List<T> GetRandomNumbersList<T>(int length)
            where T : IConvertible
        {
            List<T> numbers = random.GetRandomNumbersList<T>(length);

            Console.Write("Generated random sequence: ");
            numbers.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();

            return numbers;
        }
    }
}