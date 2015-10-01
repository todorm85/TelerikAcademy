using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Commons
{
    public static string ToString<T>(IEnumerable<T> collection)
    {
        //StringBuilder sb = new StringBuilder("[ ");
        StringBuilder sb = new StringBuilder();
        foreach (var item in collection)
        {
            sb.Append(item);
            sb.Append(Environment.NewLine + Environment.NewLine);
        }

        //sb.Append("]");
        return sb.ToString();
    }

    public static void PrintDelimiter(this string message)
    {
        string delimiter = new string('-', 50);
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine(message);
        Console.WriteLine(delimiter);
    }
}
