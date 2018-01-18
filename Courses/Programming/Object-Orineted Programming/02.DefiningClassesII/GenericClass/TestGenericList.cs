using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass
{
    class TestGenericList
    {
        static void Main()
        {
            Console.WriteLine("Initialize GenericList<double> testList and set capacity to 5");
            int capacity = 5;
            Console.WriteLine("OK");
            GenericList<double> testList = new GenericList<double>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                testList.AddElement(i*2.35);
            }
            Console.WriteLine("\n[Trying to insert one more element 35.6 above specified capacity]");
            try
            {
                testList.AddElement(35.6);
                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("[Expected exception message]:\n{0}",ex.Message));                
            }

            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("\n[Removing first element!]");
            testList.RemoveElement(0);
            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("\n[Trying to insert at index -1]");
            try
            {
                testList.InsertElement(2.5,-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("[Expected exception message]:\n{0}", ex.Message));
            }

            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("\n[Trying to insert 17.5 at index 1]");
            testList.InsertElement(17.5, 1);
            Console.WriteLine("testList.ToString() output: {0}", testList);

            Console.WriteLine("\n[Trying to insert 2.5 at index 1 when list is at max capacity]:");
            try
            {
                testList.InsertElement(2.5, 1);
                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("[Expected exception message]:\n{0}", ex.Message));
            }

            GenericList<double> testList2 = new GenericList<double>(1);
            Console.WriteLine("\n[Trying to remove element from empty list]");
            try
            {
                testList2.RemoveElement(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("[Expected exception message]:\n{0}", ex.Message));
            }

            Console.WriteLine("\n[Get element at index 1]");
            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("testList.GetElement(1) output: {0}", testList.GetElement(1));
            Console.WriteLine("\n[Get element at index -1]");
            try
            {
                testList.GetElement(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("[Expected exception message]:\n{0}", ex.Message));
            }

            Console.WriteLine("\n[Find element 2.6 index]");
            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("testList.FindElement(2.6) output: {0}", testList.FindElement(2.6));
            Console.WriteLine("\n[Find element 2.35 index]");
            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("testList.FindElement(2.35) output: {0}", testList.FindElement(2.35));

            Console.WriteLine("\n[Return element at index 2]");
            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("testList[2] output: {0}", testList[2]);

            Console.WriteLine("\n[Return max element]");
            Console.WriteLine("[Insert 50 at index 2]");
            testList.InsertElement(50, 2);
            Console.WriteLine(testList);
            Console.WriteLine("testList.Max() output: {0}",testList.Max());

            Console.WriteLine("\n[Return min element]");
            Console.WriteLine("[Insert -50 at index 4]");
            testList.InsertElement(-50, 4);
            Console.WriteLine("testList.ToString() output: {0}", testList);
            Console.WriteLine("testList.Min() output: {0}", testList.Min());     

            Console.WriteLine("\n[Clear list]");
            testList.ClearList();
            Console.WriteLine("testList.ToString() output: {0}",testList);


        }
    }
}
