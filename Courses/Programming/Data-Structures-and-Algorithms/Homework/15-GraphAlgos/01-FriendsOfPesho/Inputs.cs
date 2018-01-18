namespace _01_FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Inputs
    {
        public static void SetInput(string num)
        {
            var outputReader = new StreamReader($@"..\..\tests\test.{num}.out.txt");
            Console.WriteLine(outputReader.ReadLine());

            var inputReader = new StreamReader($@"..\..\tests\test.{num}.in.txt");
            Console.SetIn(inputReader);
        }
    }
}
