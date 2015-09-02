using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        public const int MaxStudentsCount = 30;
        private ICollection<Student> students;
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course name cannot be empty or whitespace!");
                }

                this.name = value;
            }
        }
        
        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }

            private set
            {
                this.students = value;
            }
        }

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<Student>();
        }

        internal void AddStudent(Student student)
        {
            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Student already added!");
            }

            if (this.Students.Count >= 30)
            {
                throw new InvalidOperationException("Maximum number of students for this course has been reached.");
            }

            this.students.Add(student);
        }

        internal void RemoveStudent(Student student)
        {
            if (!this.Students.Contains(student))
            {
                throw new InvalidOperationException("Student has not been added to this course!");
            }

            this.students.Remove(student);
        }
    }
}
