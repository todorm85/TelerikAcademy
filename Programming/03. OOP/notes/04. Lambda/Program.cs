using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            string delimiter = new string('-', 50);
            Console.WriteLine("\n\nTest1");
            Console.WriteLine(delimiter);

            // Finding, Removing elements
            List<int> list = new List<int>() { 1, 2, 3, 4 };
            List<int> evenNumbers = list.FindAll((x) => x % 2 == 0);
            foreach (var item in evenNumbers)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nTest2");
            Console.WriteLine(delimiter);

            evenNumbers.RemoveAll(x => x > 3);
            foreach (var item in evenNumbers)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nTest3");
            Console.WriteLine(delimiter);

            // Soting
            var pets = new[]
            {
                new {Name="Sharo", Age=8},
                new {Name="Rex", Age=4},
                new {Name="Strela", Age=1},
                new {Name="Bora", Age=3},
            };

            var sortedPets = pets.OrderBy(pet => pet.Age);

            foreach (var pet in sortedPets)
            {
                Console.WriteLine("{0} -> {1}", pet.Name, pet.Age);
            }

            Console.WriteLine("\n\nTest4");
            Console.WriteLine(delimiter);

            // Process with codeblock
            List<int> list2 = new List<int>() { 20, 1, 4, 8, 9, 44 };
            List<int> result2 = list2.FindAll(i =>
            {
                Console.WriteLine("value of current element is: {0}", i);
                return (i % 2) == 0;
            });

            foreach (var even in result2)
            {
                Console.Write(even + " ");
            }

            Console.WriteLine("\n\nTest5");
            Console.WriteLine(delimiter);

            // Lambda stored in delegates (anonymous methods with predefined delegates)
            // Standard delegates are predefined in .NET
            // Func<TResult>, Func<T, TResult> and so on...
            // Func<> is a delegate type that can take several arguements and last one
            // always specifies the return type
            // if we want a standart delegate with void returned type we use Action<T>
            // Action<T> - void delegate with param T
            // Func<T,TResult> - result delegate with param T and return result RTresult
            // the result type is always the last
            Func<bool> boolFunc = () => true;
            // the delegate boolFunc will always return true and takes 0 args
            Func<int, bool> intFunc = (x) => x < 10;
            if (boolFunc() && intFunc(5))
            {
                Console.WriteLine("Both delegate returned true");
            }
            // predicate is a predefined delegate with following structure
            // public delegate bool Predicate<T>(T arg);
            // their meaaning is define a way to check if an object meets criteria

            Console.WriteLine("\n\nTest6");
            Console.WriteLine(delimiter);

            List<string> towns = new List<string> { "Sofia", "Plovdiv", "Radomir", "Petrich" };
            List<string> townsWithR = towns.FindAll(x => x.ToLower().Split('r').Length > 1);
            foreach (var town in townsWithR)
            {
                Console.Write(town + " ");
            }

            // so lambdas are anonymous functions that take some args and return bool result
            // the bove can be written with anonymous method
            towns = new List<string> { "Sofia", "Plovdiv", "Radomir", "Petrich" };
            townsWithR = towns.FindAll(delegate(string town)
            {
                return town.ToLower().Split('r').Length > 1;
            });

            foreach (var town in townsWithR)
            {
                Console.Write(town + " ");
            }

            Console.WriteLine("\n\nTest7");
            Console.WriteLine(delimiter);

            Action<int> act = (number) =>
                {
                    Console.WriteLine(number + 1);
                };
            act(5);
            Action<string> actStr = delegate(string str)
            {
                Console.WriteLine(str + 1);
            };
            actStr("8");

            Console.WriteLine("\n\nTest8");
            Console.WriteLine(delimiter);

            Func<int, string> func1 = (num) =>
                {
                    Console.WriteLine("Executing func1({0})", num);
                    return num.ToString();
                };
            Console.WriteLine("returned: " + func1(1));
        }
    }
}
