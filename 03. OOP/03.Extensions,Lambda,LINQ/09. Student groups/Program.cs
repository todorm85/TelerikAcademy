using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Student_groups
{
    // for extension method ToString<T> I use reference to 02. IEnumerable extension

    public class Group
    {
        private int groupNumber;
        private string department;

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Group number cannot be negative");
                }

                this.groupNumber = value;
            }
        }

        public string Department
        {
            get
            {
                return this.department;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Department name cannot be empty");
                }
                this.department = value;
            }
        }

        public Group(int group, string department)
        {
            this.GroupNumber = group;
            this.Department = department;
        }

        public override string ToString()
        {
            return String.Format("\nGroup: {0}, Dep.: {1}\n", this.GroupNumber, this.Department);
        }
    }

    public class Student
    {
        // FIELDS
        private string firstName;
        private string lastName;
        private int fn;
        private string mail;
        private List<double> marks;
        private int groupNumber;

        // PROPERTIES
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student name cannot be empty!");
                }

                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student last name cannot be empty!");
                }

                this.lastName = value;
            }
        }
        public int FN
        {
            get
            {
                return this.fn;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Faculty number cannot be negative!");
                }

                this.fn = value;
            }
        }
        public string Tel { get; set; }
        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                if (value.Split('@').Length != 2 || value.Contains(' '))
                {
                    throw new ArgumentException("Invalid mail address entry for student!");
                }

                this.mail = value;
            }
        }
        public double[] Marks
        {
            get
            {
                if (this.marks != null)
                {
                    return this.marks.ToArray();
                }
                else
                {
                    return new double[0];
                }
            }
            set
            {
                List<double> newMarks = new List<double>(value);
                foreach (var mark in newMarks)
                {
                    if (mark < 2 || mark > 6)
                    {
                        throw new ArgumentException("Invalid student mark value. Must be in range [2-6]");
                    }
                }

                this.marks = value.ToList();
            }
        }
        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Group number cannot be negtive!");
                }

                this.groupNumber = value;
            }
        }

        // CONSTRUCTORS
        public Student(string firstName, string lastName, int fn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
        }
        public Student(string firstName, string lastName, int fn, string tel,
            string mail, int groupNumber, params double[] marksInput)
            : this(firstName, lastName, fn)
        {
            this.Tel = tel;
            this.Mail = mail;
            this.Marks = marksInput;
            this.GroupNumber = groupNumber;
        }

        //METHODS
        public override string ToString()
        {
            return String.Format("\n{0} {1}, FN: {2}, group: {6}\n tel: {3}, mail: {4},\n marks: {5}\n",
                FirstName,LastName,FN,Tel,Mail,Marks.ToString<double>(),GroupNumber);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            

            List<Student> students = new List<Student>(
                new Student[]
                {
                    new Student("Ivan","Ivanov",444506,"02358875","ivan@abv.bg",2,2,3,3,6,5),
                    new Student("Petar","Georgiev",665385,"06474598","pe6o@mail.bg",2,2,4),
                    new Student("Stamat","Kabakchiev",345206,"02545876","stamat@abv.bg",1,2,6,5,5),
                    new Student("Nagazigo","Nadovara",143216,"17485986","nagazigo@abv.bg",1,6,5,5),
                    new Student("Dragan","Tsankov",233421,"02857648","dragan@abv.bg",2,2,3,5),
                });

            Console.WriteLine(students.ToString<Student>());

            PrintDelimiter("\nProblem 9: Students in group 2 with LINQ:");
            var extractedStudents =
                from student in students
                where student.GroupNumber == 2
                select student;
            Console.WriteLine(extractedStudents.ToString<Student>());

            PrintDelimiter("\nProblem 10: Students in group 2 with Extension methods and Lambdas:");
            extractedStudents = students.Where(student => student.GroupNumber == 2);
            Console.WriteLine(extractedStudents.ToString<Student>());

            PrintDelimiter("\nProblem 11: students by email abv.bg with LINQ");
            extractedStudents =
                from student in students
                where student.Mail.Contains("@abv.bg")
                select student;
            Console.WriteLine(extractedStudents.ToString<Student>());

            PrintDelimiter("\nProblem 12: students by phone in Sofia with LINQ");
            extractedStudents =
                from student in students
                where student.Tel.StartsWith("02")
                select student;
            Console.WriteLine(extractedStudents.ToString<Student>());

            PrintDelimiter("\nProblem 15: students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN)");
            var extractedStudentsMarks = students.Where(student => student.FN.ToString().Substring(4, 2) == "06").Select(student => student.Marks);
            Console.WriteLine("All source students:");
            Console.WriteLine(students.ToString<Student>());
            Console.WriteLine("Extracted marks:");
            foreach (var collection in extractedStudentsMarks)
            {
                foreach (var mark in collection)
                {
                    Console.Write(mark + " ");
                }
            }

            ////            Problem 16.* Groups
            ////•	Create a class Group with properties GroupNumber and DepartmentName.
            ////•	Introduce a property GroupNumber in the Student class.
            ////•	Extract all students from "Mathematics" department.
            ////•	Use the Join operator.
            PrintDelimiter("\n\nProblem 16: Groups");
            var groups = new[]
            {
                new Group(1,"Physics"),
                new Group(2,"Mathematics"),
                new Group(3,"Physics"),
                new Group(4,"Applied science"),
            };
            Console.WriteLine("All students: ");
            Console.WriteLine(students.ToString<Student>());
            Console.WriteLine("Groups: ");
            Console.WriteLine(groups.ToString<Group>());

            Console.WriteLine("Students in Mathematics department:");
            extractedStudents =
                from student in students
                join gr in groups on student.GroupNumber equals gr.GroupNumber
                where gr.Department == "Mathematics"
                select student;
            Console.WriteLine(extractedStudents.ToString<Student>());

            ////    Problem 18. Grouped by GroupNumber
            ////•	Create a program that extracts all students grouped by GroupNumber and then prints them to the console.
            ////•	Use LINQ.

            PrintDelimiter("\n\nProblem 18: Groups with LINQ");
            var studentsByGroup =
                from student in students
                group student by student.GroupNumber into newGroup
                orderby newGroup.Key
                select newGroup;
            foreach (var group in studentsByGroup)
            {
                PrintDelimiter("");
                Console.WriteLine("Group: {0}", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }

            ////            Problem 19. Grouped by GroupName extensions
            ////•	Rewrite the previous using extension methods.

            PrintDelimiter("\n\nProblem 19: Groups with Extensions and lambda");
            studentsByGroup = students.GroupBy(student => student.GroupNumber).OrderBy(group => group.Key);
            foreach (var group in studentsByGroup)
            {
                PrintDelimiter("");
                Console.WriteLine("Group: {0}", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void PrintDelimiter(string message)
        {
            string delimiter = new string('-', 50);

            Console.WriteLine(message);
            Console.WriteLine(delimiter);
        }
    }
}
