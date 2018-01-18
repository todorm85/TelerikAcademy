using System;
using System.Collections;
using System.Collections.Generic;
namespace MethodsLecture
{
    public class LectureNotes
    {
        // the lecture is very useful at the end for method testing
        // notes on Methods 2014 Niki
        static void Main()
        {
            string breakLine = new string('-', 50) + "\n";
            PrintMax(4.5, 3.8);
            PrintMaxDefault(5); //no second parameter defined so default used for second
            PrintMaxDefault(5, 6);  //no default used
            PrintMaxDefault(b: 4);  // use a default, but assign 4 to b   
            Math.Pow(y: 5, x: 3); // 3 to the pow of 5
            SayMonth(6);
            Console.Write(breakLine);
            TrianglePrint(15);
            List<int> intList = new List<int>
        { 
            5, 4, 3, 7 , -2
        };
            Console.WriteLine("All positive: " + AreAllPositive(intList));
            int[] intArr = { 3, 5, 3, 65 };
            Console.WriteLine("All positive: " + AreAllPositive(intArr));

            Console.WriteLine(CalcSum(4, 3, 2, 5, 7));  // CalcSum can have various number of parameters
            Console.WriteLine(CalcSum(1, 2, 5));
        }

        static void PrintMax(double a, double b)
        {
            if (a > b)
            {
                Console.WriteLine("Max: " + a);
            }
            else if (a < b)
            {
                Console.WriteLine("Max: " + b);
            }
            else
            {
                Console.WriteLine("Numbers are equal");
            }
        }

        static void PrintMaxDefault(double a = 3, double b = 1.5)   // if no second parameter provided assign 1.5
        {
            if (a > b)
            {
                Console.WriteLine("Max: " + a);
            }
            else if (a < b)
            {
                Console.WriteLine("Max: " + b);
            }
            else
            {
                Console.WriteLine("Numbers are equal");
            }
        }

        static void SayMonth(int index)
        {
            if (index < 1 || index > 12)
            {
                Console.WriteLine("Not a Valid Month Number");
                return;
            }
            string[] months = 
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
        };

            Console.WriteLine(months[index - 1]);
        }

        static void TrianglePrint(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int ii = 0; ii <= i; ii++)
                {
                    Console.Write(ii + 1 + " ");
                }

                Console.WriteLine();
            }

            for (int i = n - 1; i > 0; i--)
            {
                for (int ii = 0; ii < i; ii++)
                {
                    Console.Write(ii + 1 + " ");
                }

                Console.WriteLine();
            }
        }

        //accepts any data types that implement interface IEnumerable (can be foreach - ed) 
        static bool AreAllPositive(IEnumerable collection)
        {
            foreach (int item in collection)
            {
                if (item < 0) return false;
            }

            return true;
        }

        //Method overloading - the same name for different methods that do different things
        static void Print(string txt)
        {
            Console.WriteLine(txt);
        }

        static void Print(int num)
        {
            Console.WriteLine(num);
        }

        static void Print(string txt, int num)
        {
            Console.WriteLine(txt + num);
        }

        public static long CalcSum(params int[] values)
        {
            long sum = 0;
            foreach (var item in values)
            {
                sum += item;
            }
            return sum;
        }
    }
}
