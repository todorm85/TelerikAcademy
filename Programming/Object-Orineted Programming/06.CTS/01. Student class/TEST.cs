using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_class
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = false;
            int testNum = 0;
            Student st1 = new Student("Pe6o","Pe6ov", "Peshistia", "8514897589");
            Student st2 = (Student)st1.Clone(); // deep copy student st1 to st2
            Student st3 = new Student("Angel", "Yavorov", "Angelov", "123450");

            st2.Ssn= (ulong.Parse(st2.Ssn) + 1).ToString(); // increase st2 ssn with 1

            testNum = 1;
            int returned = st1.CompareTo(st2);
            result = (returned == -1) ? true : false;
            PrintResult(testNum, result);

            testNum = 2;
            st2.Ssn = (ulong.Parse(st2.Ssn) - 2).ToString();
            returned = st1.CompareTo(st2);
            result = (returned == 1) ? true : false;
            PrintResult(testNum, result);

            testNum = 3;
            st2.Ssn = (ulong.Parse(st2.Ssn) + 1).ToString();
            returned = st1.CompareTo(st2);
            result = (returned == 0) ? true : false;
            PrintResult(testNum, result);

            testNum = 4;
            returned = st1.CompareTo(st3);
            result = (returned == 1) ? true : false;
            PrintResult(testNum, result);

            testNum = 5;
            st2 = (Student)st1.Clone();
            result = st1 == st2;
            PrintResult(testNum, result);

            testNum = 6;
            result = !(st1 == st3);
            PrintResult(testNum, result);

            testNum = 7;
            result = st1 != st3;
            PrintResult(testNum, result);

            testNum = 8;
            result = !(st1 != st2);
            PrintResult(testNum, result);

            testNum = 9;
            string resultStr = st1.ToString();
            string expectedStr = "Pe6o Peshistia, SSN = 8514897589";
            result = (resultStr == expectedStr) ? true : false;
            PrintResult(testNum, result);
        }

        static void PrintResult(int test, bool result, string message = "")
        {
            var delimiter = new String('-', 50);
            Console.WriteLine("{0}\nTest {1} passed: {2}{3}",delimiter,test,result,"\n"+message);
        }
    }
}
