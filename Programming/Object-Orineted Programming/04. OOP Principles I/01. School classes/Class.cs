using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.School_classes
{
    public class Class : SchoolObject
    {
        private static int lastClassID = 1;
        private List<Teacher> teachers;
        private readonly string id;

        public Class()
        {
            this.id = lastClassID.ToString();
            this.teachers = new List<Teacher>();
        }

        public string Id
        {
            get { return id; }
        }

        private List<Teacher> Teachers
        {
            get { return teachers; }
            set { teachers = value; }
        }

        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new NullReferenceException();
            }

            this.Teachers.Add(teacher);
        }

        public void ViewTeachers()
        {
            foreach (var teacher in this.Teachers)
            {
                Console.WriteLine(teacher.Name);
            }
        }

        public void RemoveTeacher(string name)
        {
            int index = this.Teachers.FindIndex(x => x.Name == name);
            this.Teachers.RemoveAt(index);
        }

        public void ClearTeachers()
        {
            this.Teachers.Clear();
        }
    }
}
