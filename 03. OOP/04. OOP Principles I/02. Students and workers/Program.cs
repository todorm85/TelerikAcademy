using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_and_workers
{
    class Program
    {
        static void Main()
        {
            "Unsorted students list:".PrintDelimiter();
            List<Student> students = new List<Student>
            {
                new Student("Petkan","Petkanov",3),
                new Student("Dragan","Draganov",3.2),
                new Student("Iva","Ivova",3.8),
                new Student("Kolio","Koliev",5),
                new Student("Mitio","Ochite",2),
                new Student("Svilen","Gvamolov",2.5),
                new Student("Peter","Peterov",2.3),
                new Student("Prodavalnik","Prodavalnikov",5.75),
                new Student("Gergan","Gerganov",6),
            };

            Console.WriteLine(Extensions.ToString(students));

            "Sorted students list:".PrintDelimiter();
            var sortedStudents = students.OrderBy(x => x.Grade);
            Console.WriteLine(Extensions.ToString(sortedStudents));

            "Unsorted workers list:".PrintDelimiter();
            List<Worker> workers = new List<Worker>
            {
                new Worker("Koralov","Petkanov",3,5),
                new Worker("Yana","Draganova",3.2,7),
                new Worker("Boris","Ivova",3.8,9),
                new Worker("Maria","Koliev",5,12),
                new Worker("Yana","Ochite",2,4),
                new Worker("Maria","Gvamolova",2.5,6),
                new Worker("Hitar","Peterov",2.3,5.5),
                new Worker("Koleda","Prodavalnikov",5.75,9.5),
                new Worker("Vasil","Gerganov",6,11),
            };

            Console.WriteLine(Extensions.ToString(workers));

            "Sorted workers list:".PrintDelimiter();
            var sortedWorkers =
                from x in workers
                orderby x.MoneyPerHour() descending
                select x;
            Console.WriteLine(Extensions.ToString(sortedWorkers));

            "Merging workers and students:".PrintDelimiter();
            List<Human> humans = new List<Human>(students);
            humans.AddRange(workers);
            Console.WriteLine(Extensions.ToString(humans));

            "Sorting by First then by last name".PrintDelimiter();
            var sortedHumans = humans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            Console.WriteLine(Extensions.ToString(sortedHumans));
        }
    }
}
