using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsHw
{
    class Program
    {
        static int employeesCount;
        static List<int>[] subs;
        static long[] salaries;
        static bool[] processedEmployees;

        static void Main(string[] args)
        {
            //Inputs.SetInput(4);

            GetInput();

            Solve();
        }

        private static void Solve()
        {
            salaries = new long[employeesCount];
            processedEmployees = new bool[employeesCount];
            int calculatedEmployees = 0;
            while (calculatedEmployees < employeesCount)
            {
                for (int i = 0; i < employeesCount; i++)
                {
                    if (processedEmployees[i])
                    {
                        continue;
                    }

                    if (subs[i].Count == 0)
                    {
                        salaries[i] = 1;
                        processedEmployees[i] = true;
                        calculatedEmployees++;
                    }
                    else if (subs[i].All(x => processedEmployees[x] == true))
                    {
                        salaries[i] = subs[i].Sum(x => salaries[x]);
                        processedEmployees[i] = true;
                        calculatedEmployees++;
                    }
                }
            }

            long totalSalary = salaries.Sum(x => x);
            Console.WriteLine(totalSalary);
        }

        private static void GetInput()
        {
            employeesCount = int.Parse(Console.ReadLine());
            subs = new List<int>[employeesCount];

            for (int i = 0; i < employeesCount; i++)
            {
                subs[i] = new List<int>();
                var input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y' || input[j] == 'y')
                    {
                        subs[i].Add(j);
                    }
                }
            }
        }
    }
}
