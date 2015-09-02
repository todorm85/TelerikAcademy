using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class StudentGroup
    {
        private ICollection<Student> students;
        private ICollection<Course> courses;
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
                    throw new ArgumentException("School name cannot be empty or null!");
                }

                this.name = value;
            }
        }
        
        public ICollection<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }

            private set
            {
                this.courses = value;
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

        public StudentGroup(string name)
        {
            this.Name = name;
            this.Courses = new List<Course>();
            this.Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new NullReferenceException("Student cannot be null!");
            }

            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException("Student already added to this school!");
            }

            if (this.Students.Any(x => x.Id == student.Id))
            {
                throw new InvalidOperationException("Students cannot have duplicate ids in same school");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new NullReferenceException("Student cannot be null!");
            }

            if (!this.Students.Contains(student))
            {
                throw new InvalidOperationException("Student has not been added to this school!");
            }

            this.students.Remove(student);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException("Course cannot be null.");
            }

            if (this.Courses.Contains(course))
            {
                throw new InvalidOperationException("Course has already been added to this school!");
            }

            var newStudents = course.Students.Where(x => !this.Students.Contains(x));
            foreach (var st in newStudents)
            {
                this.AddStudent(st);
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
            {
                throw new NullReferenceException("Course cannot be null.");
            }

            if (!this.Courses.Contains(course))
            {
                throw new InvalidOperationException("Course does not exist in this school");
            }

            this.courses.Remove(course);
        }
    }
}
