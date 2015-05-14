using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime minDate = DateTime.Parse("1/1/1980");
            DateTime maxDate = new DateTime(2013, 12, 31);

            Exception intRange1 = new InvalidRangeException<int>(1, 100);
            Exception dateRange1 = new InvalidRangeException<DateTime>("Some custom message...", minDate, maxDate);

            Console.Write("Enter a number between 1 and 100: ");
            int input1 = int.Parse(Console.ReadLine());
            try
            {
                if (input1 > 100 || input1 < 0)
                {
                    throw intRange1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Enter date between 1/1/1980 and 31/12/2013: ");
            DateTime input2 = DateTime.Parse(Console.ReadLine());

            try
            {
                if (input2 < minDate || input2 > maxDate)
                {
                    throw dateRange1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
