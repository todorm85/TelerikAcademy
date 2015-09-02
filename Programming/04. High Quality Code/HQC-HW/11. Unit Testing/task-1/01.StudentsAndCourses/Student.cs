using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        public const int MaxValidId = 99999;
        public const int MinValidId = 10000;
        private int id;
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
                    throw new ArgumentException("Must provide name for student. Cannot be empty or whitespace.");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value < MinValidId || MaxValidId < value)
                {
                    throw new ArgumentException("Student Id out of range!");
                }

                this.id = value;
            }
        }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public void JoinCourse(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException("Course cannot be null");
            }

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException("Course cannot be null");
            }

            course.RemoveStudent(this);
        }
    }
}
