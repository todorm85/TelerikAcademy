using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    /// <summary>
    /// Extracts a subsequence of a sequence by a provided count of elements to be extracted and starting index. 
    /// Extracts from the starting index to the end of the sequence.
    /// If the resulting sequence from the provided starting index is shorter than the provided count of elements to extract returns the whole sequence.
    /// </summary>
    /// <param name="arr">The sequence from which to extract.</param>
    /// <param name="startIndex">The starting index of extraction.</param>
    /// <param name="count">The number of elements to extract.</param>
    /// <returns>Returns the extracted sequence.</returns>
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (startIndex < 0 || arr.Length <= startIndex)
        {
            throw new ArgumentOutOfRangeException("Start index must be in the index range of the provided array.");
        }

        if ((startIndex + count) >= arr.Length )
        {
            count = arr.Length - startIndex;
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Extracts a certian number of characters from a string, starting from the end. If the string is 
    /// shorter than the provided count of characters to be extracted returns the whole string.
    /// </summary>
    /// <param name="str">The provided string.</param>
    /// <param name="count">The number of chars to be extracted</param>
    /// <returns>The extracted string.</returns>
    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            count = str.Length;
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        if (number <= 2)
        {
            return false;
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        int numberTwentyTree = 23;
        if (CheckPrime(numberTwentyTree))
        {
            Console.WriteLine("{0} is prime", numberTwentyTree);
        }
        else
        {
            Console.WriteLine("{0} is not a prime", numberTwentyTree);
        }

        int numberThirtyTree = 33;
        if (CheckPrime(numberTwentyTree))
        {
            Console.WriteLine("{0} is prime", numberThirtyTree);
        }
        else
        {
            Console.WriteLine("{0} is not a prime", numberThirtyTree);
        }


        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
