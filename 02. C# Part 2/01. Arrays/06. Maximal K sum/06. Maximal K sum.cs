using System;
//### Problem 06. Maximal K sum
//*	Write a program that reads two integer numbers `N` and `K` and an array of `N` elements from the console.
//*	Find in the array those `K` elements that have maximal sum.
class Program
{
    static void Main()
    {
        Console.Write("Enter integer n (-2,147,483,648 to 2,147,483,647): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter integer k (-2,147,483,648 to 2,147,483,647): ");
        int k = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int indx = 0; indx < n; indx++)
        {
            Console.Write("arr[{0}] = ", indx);
            arr[indx] = int.Parse(Console.ReadLine());
        }

        int sum = 0;

        for (int sortIndx = 0; sortIndx < k; sortIndx++) //we need only the first biggest k elements so the cycle stops at sortIndx=k
        {
            int max = int.MinValue; //initially we assign the min possible value to max variable

            for (int indx = 0; indx < n; indx++)    //cycle to find the biggest number in arr
            {
                if (arr[indx] > max) max = arr[indx];
            }

            for (int indx = 0; indx < n; indx++)    //cycle to exclude the biggest number from the search for the second biggest by giving it the minimum possible value
            {
                if (arr[indx] == max)
                {
                    arr[indx] = int.MinValue;
                    break;  //we need this break because we only need to exclude one of the biggest numbers if there are more than one equal biggest numbers
                }
            }

            sum += max; //we increment the sum with the current biggest
        }

        Console.WriteLine(sum);
    }
}

