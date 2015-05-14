using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.School_classes
{
    class Program
    {
        static void Main()
        {
            "Test1: teacher1 with two disciplines".PrintDelimiter();
            Teacher teacher1 = new Teacher("testTeacher");
            teacher1.AddDiscipline(new Discipline("testDiscipline1"));
            teacher1.AddDiscipline(new Discipline("testDiscipline2"));
            teacher1.ViewDisciplines();

            "Test2: after testDiscipline1 removed".PrintDelimiter();
            teacher1.RemoveDiscipline("testDiscipline1");
            teacher1.ViewDisciplines();

            "Test3: create two students and test their unique id(class number)".PrintDelimiter();
            Student student1 = new Student("student1");
            Student student2 = new Student("student2");
            Console.WriteLine("{0} class number: {1}",student1.Name, student1.ClassNumber);
            Console.WriteLine("{0} class number: {1}", student2.Name, student2.ClassNumber);
        }
    }
}
